using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationPwsz.Models;
using WebApplicationPwsz.Models.Models;
using System.Data.Entity;
using WebApplicationPwsz.Classes;

namespace WebApplicationPwsz.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            using (var db = new DbUsersEntities())
            {
                Posts posts = new Posts();
            posts.SessionUser=(users1)Session["Users"];
                Session["TopBar"] = 2;
                return View(posts.GetPosts());
            }
        }
        public ActionResult Like(int idPost)
        {
            using (var db = new DbUsersEntities())
            {
                //  var u = (users1)Session["Users"];
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

                return View();
            }

        }
        public ActionResult AddFriends(int idFriends)
        {
            using (var db = new DbUsersEntities())
            {
                  var u = (users1)Session["Users"];
                db.Friends.Add(new Friends { idFriends = idFriends ,id=u.id});
                
                db.SaveChanges();

                return View();
            }

        }  public ActionResult FrendsListPage()
        {
            using (var db = new DbUsersEntities())
            {
                //  var u = (users1)Session["Users"];
                //db.Friends.Add(new Friends { idFriends = idFriends ,id=u.id});

                //db.SaveChanges();
                Posts posts = new Posts();
                posts.SessionUser = (users1)Session["Users"];
                Session["TopBar"] = 2;
                var a = posts.GetFriends(/*posts.SessionUser.id*/1);
                MainPageViewModel mainPageViewModel = new MainPageViewModel();
                mainPageViewModel.Frends = a;
                return View(mainPageViewModel);
            }

        }
        public ActionResult Comment(int idPost, string text)
        {
            using (var db = new DbUsersEntities())
            {
                try
                {
                    var u = (users1)Session["Users"];
                    var post = db.Comments.Add(new Comments
                    {
                        //TODO POprawić baze  Post id i relacje
                        content = text,
                        postIdTrue = idPost,
                        createDate = DateTime.Now,
                        username = u.imie.Trim() + " " + u.nazwisko.Trim()

                    });
                    db.SaveChanges();
                    return RedirectToAction("Index", "Post");
                }
                catch (Exception ex)
                {
                    return View(ex);
                }
            }

        }

        public ActionResult SavePost(string content)
        {
            Posts posts = new Posts();
            posts.SessionUser=(users1)Session["Users"];
            posts.AddPorst(content);

            return View();
        }
    }
}