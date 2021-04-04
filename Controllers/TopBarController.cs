using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApkTest.Controllers
{
    public class TopBarController : Controller
    {
        // GET: TopBar
        public ActionResult TopBar()
        {
            Session["TopBar"] = 1;
            return View();
        } 
        public ActionResult Panel()
        {
           
            return View();
        }


        public ActionResult PanelZew()
        {

            return View();
        }

        public ActionResult Tablica()
        {

            return View();
        }
    }
}