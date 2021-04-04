using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationPwsz.Models;
using WebApplicationPwsz.Models.Models;
using System.Data.Entity;
namespace WebApplicationPwsz.Classes
{
    public class Posts
    {
        DbUsersEntities db = new DbUsersEntities();
        public Post post { get; set; }
        public List<Frends> Frends { get; set; }
        public users1 SessionUser { get; set; }

        public void AddPorst(string content)
        {
            post.content = content;
            post.title = SessionUser.imie + " " + SessionUser.nazwisko;
            post.createDate = DateTime.Now;
            db.Post.Add(post);
            db.SaveChanges();
        }
        public PostsViewModel GetPosts()
        {
            var post = db.Post.Include(x => x.Comments).ToList();
            PostsViewModel posts = new PostsViewModel();
            posts.posts.AddRange(post);
            return posts;
        }
        public void Like(int idPost)
        {
            var post = db.Post.FirstOrDefault(x => x.id == idPost);
            if (post.likes == null)
            {
                post.likes = 1;
            }
            else
            {
                post.likes += 1;
            }
            db.SaveChanges();
        }
        public void AddFriends(int idFriends)
        {
            db.Friends.Add(new Friends { idFriends = idFriends, idUser = SessionUser.id ,id=1});
            db.SaveChanges();
        }
        public List<Frends> GetFriends(int idUser)
        {
            return db.Friends.Include(x=>x.users1).Where(x => x.idUser == idUser).Select(friends =>
                new Frends
                {
                    id = friends.id,
                    idUser = friends.idUser,
                    idFriends = friends.idFriends,
                    imie = friends.users1.imie,
                    nazwisko = friends.users1.nazwisko,
                    wiek = friends.users1.wiek,
                    miejscowosc = friends.users1.miejscowosc,
                    plec = friends.users1.plec,
                    login = friends.users1.login,
                    email = friends.users1.email,
                    haslo = friends.users1.haslo,
                })
                .ToList();
        }
        public List<Friends> GetAllUsers()
        {
            return db.Friends.ToList();
        }
        public void RemoveFriends(int idFriends)
        {
            var friends = db.Friends.FirstOrDefault(x => x.id == idFriends);
            db.Friends.Remove(friends);
            db.SaveChanges();
        }
        public void AddComment(int idPost, string text)
        {
            try
            {
                var post = db.Comments.Add(new Comments
                {
                    //TODO POprawić baze  Post id i relacje
                    content = text,
                    postIdTrue = idPost,
                    createDate = DateTime.Now,
                    username = SessionUser.imie.Trim() + " " + SessionUser.nazwisko.Trim()

                });
                db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }



    }

    public class Frends
    {
        public int id { get; set; }
        public int? idFriends { get; set; }
        public int? idUser { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public int? wiek { get; set; }
        public string miejscowosc { get; set; }
        public string FullName { get {
                return this.nazwisko + " " + this.imie; } }
        public string FullNameRevers { get {
                return this.imie + " " + this.nazwisko; } }
        public bool? plec { get; set; }
        public bool isActive { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string haslo { get; set; }
        public System.DateTime? data_urodzenia { get; set; }
        public bool? login_flag { get; set; }
        public byte[] imageData { get; set; }
        public Frends(Friends friends)
        {
            id = friends.id;
            idFriends = friends.idFriends;
            idUser = friends.idUser;

        }
        public Frends()
        {


        }
        public Frends(users1 friends)
        {
            id = friends.id;
            idFriends = friends.idFriends;
            imie = friends.imie;
            nazwisko = friends.nazwisko;
            wiek = friends.wiek;
            miejscowosc = friends.miejscowosc;
            plec = friends.plec;
            login = friends.login;
            email = friends.email;
            haslo = friends.haslo;
        }
    }
}