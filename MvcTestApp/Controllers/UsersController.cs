using MvcTestApp.DBMan;
using MvcTestApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTestApp.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/

        public ActionResult Index()
        {

            SqlDbConsultor consultor = new SqlDbConsultor();
            consultor.conn.setConnectionString("MadaschiAzure");
            List<UsersModel> users = consultor.getUsersList();

            return View(users);
        }


        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Update(int personId)
        {

            
            SqlDbConsultor consultor = new SqlDbConsultor();
            consultor.conn.setConnectionString("MadaschiAzure");

            UsersModel user = consultor.GetUser(personId);
          



            return View("Update", user);
        }

         [HttpPost]
        public ActionResult Delete(int personId)
        {
        

            SqlDbConsultor consultor = new SqlDbConsultor();
            consultor.conn.setConnectionString("MadaschiAzure");

            consultor.DeleteUser(personId);
          


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateNewUser(UsersModel user)//string firstName, string lastName, string address, string city)
        {

     
            SqlDbConsultor consultor = new SqlDbConsultor();
            consultor.conn.setConnectionString("MadaschiAzure");

            consultor.CreateNewUser(user);

            List<UsersModel> users = consultor.getUsersList();


            return View("Index", users);
        }

        [HttpPost]
        public ActionResult UpdateUser(string firstName, string lastName, string address, string city, int personId)
        {

            UsersModel user = new UsersModel();
            user.firstName = firstName;
            user.lastName = lastName;
            user.address = address;
            user.city = city;
            user.personId = personId;

            SqlDbConsultor consultor = new SqlDbConsultor();
            consultor.conn.setConnectionString("MadaschiAzure");

            consultor.updateUser(user);

            List<UsersModel> users = consultor.getUsersList();


            return View("Index", users);
        }


    }
}
