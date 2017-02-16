using MvcTestApp.Models;
using MvcTestApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTestApp.Controllers
{
    public class SubscriberController : Controller
    {
        //
        // GET: /Subscriber/

        public ActionResult Index()
        {
            DBMan.DbConsultor consultor = new DBMan.DbConsultor();
            
            List<SubscriberViewModel> subs_list = consultor.getSubsList();
            
            return View();
        }

    }
}
