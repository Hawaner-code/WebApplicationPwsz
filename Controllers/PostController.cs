using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationPwsz.Models;

namespace WebApplicationPwsz.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult SavePost(string content)
        {
            using (var db = new DbUsersEntities())
            {
              //  var u = (users1)Session["Users"];
                var u = db.users1.First();
                db.Post.Add(new Post
                {
                    content = content,
                    title = u.imie + " " + u.nazwisko,
                    createDate =DateTime.Now
                    
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