using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationPwsz.Models;
using WebApplicationPwsz.Models.Models;
using System.Data.Entity;
namespace WebApplicationPwsz.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            using (var db = new DbUsersEntities())
            {
                //  var u = (users1)Session["Users"];
                var post = db.Post.Include(x => x.Comments).ToList();
                PostsViewModel posts = new PostsViewModel();
                posts.posts.AddRange(post);//zrobic wyswietlanie
                return View(posts);
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
            using (var db = new DbUsersEntities())
            {
                var u = (users1)Session["Users"];
                //var u = db.users1.First();
                db.Post.Add(new Post
                {
                    content = content,
                    title = u.imie + " " + u.nazwisko,
                    createDate = DateTime.Now

                });
                db.SaveChanges();

                //Store the products to a session

                //   Session["Users"] = user;

                //To get what you have stored to a session

                //var products = Session["products"] as List<Product>;

                // to clear the session value

                //Session["products"] = null;

                return View();

                // else return Json("nie rafdfsf", JsonRequestBehavior.AllowGet);
            }
            return View();
        }
    }
}