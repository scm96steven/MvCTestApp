using MvcTestApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MvcTestApp
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

      

            return View();
        }
        public ActionResult Chiquitica()
        {



            return View();
        }

    }
}
