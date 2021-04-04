using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationPwsz.Models;
using WebApplicationPwsz.Models.Models;

namespace WebApplicationPwsz.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PasekGora()

        {
            return View();
        }
        
        public ActionResult Register()
        {
            User user = new User();
            return View();
        }

        [HttpPost]
        public ActionResult ShortRegister()
        {
            return View();
        } 
        public ActionResult TestLogin(string login, string haslo)
        {
            using (var db = new DbUsersEntities())
            {
                var users = db.users1.Any(x => x.login == login && x.haslo == haslo);
                var user = db.users1.FirstOrDefault(x => x.login == login && x.haslo == haslo);


                //Store the products to a session

                Session["Users"] = user;

                //To get what you have stored to a session
              
                //var products = Session["products"] as List<Product>;

               // to clear the session value

                //Session["products"] = null;
                if (user !=null)
                {
                    return View();
                }
                else return Json("nie rafdfsf", JsonRequestBehavior.AllowGet);
            }
        }




       
        public ActionResult Login(string login,string password)
        {
                using (var db = new DbUsersEntities())
            {
                if (login != null&& password != null)
                {
                     var user = db.users1.FirstOrDefault(x => x.login == login && x.haslo == password);
                   
                    if (user != null)
                    {
                        Session["Users"] = user;
                        Session["UserName"] = user.imie+" "+ user.nazwisko;
                        Session["TopBar"] = 2;
                        return RedirectToAction("Index","Post");// View("~/Views/Post/index.cshtml", post);
                    }
                    else return Json("nie rafdfsf", JsonRequestBehavior.AllowGet);
                    return View();
                }

                else { ViewData["err"] = "nie poprawny login lub hasło";
                    return View();
                }


            }

        }


        public ActionResult TestReg(string imie, string nazwisko, string  Dataurodzenia,  string Miejscowosc, bool? plec,  string login,  string email)
        {
            try
            {
              var Date=  Convert.ToDateTime(Dataurodzenia);
                int wiek = Date.Year - DateTime.Now.Year;
            string i = imie + nazwisko;
            using (var db =new DbUsersEntities()) {
                db.users1.Add(new users1
                {
                    login = login,
                    data_urodzenia = Date,
                    email = email,
                  //  haslo = haslo,
                    imie = imie,
                    wiek = wiek,
                    miejscowosc = Miejscowosc,
                    nazwisko = nazwisko,
                    plec = plec,

                });
                    db.SaveChanges();
                    };

                var data = new { Message = i };
            return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }
            // return View();
        }
    }
}