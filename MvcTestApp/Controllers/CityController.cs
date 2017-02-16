using MvcTestApp.DBMan;
using MvcTestApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTestApp.Controllers
{
    public class CityController : Controller
    {
        //
        // GET: /City/

        public ActionResult Index()
        {

            
            return View();
        }

        public ActionResult Search()
        {


            return View();
        }

    [HttpPost]
        public ActionResult SelectAndQueryDatabase(string dbValue)
        {
            
            DbConsultor consultor = new DbConsultor();
            consultor.conn.setConnectionString(dbValue);



            List<CityViewModel> cityList = consultor.getCityList();
        

            return View("Index",cityList);
        }

    [HttpPost]
    public ActionResult SearchCitiesInDatabase(string dbValue, string cityName)
    {

        DbConsultor consultor = new DbConsultor();
        consultor.conn.setConnectionString(dbValue);



        List<CityViewModel> cityList = consultor.ifCityExists(cityName);

  
        return View("Search", cityList);
    }


    }
}
