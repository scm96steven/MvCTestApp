using MvcTestApp.Models.Models;
using MvcTestApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcTestApp.DBMan
{
    public class SqlDbConsultor
    {
        public DataLayer.SQLConnection conn;

        public SqlDbConsultor()
        {
            conn = new DataLayer.SQLConnection();    
        }


        public List<UsersModel> getUsersList()
        {

            DataTable table = this.conn.executeQuery("SELECT * FROM Persons ");
            List<UsersModel> usersList = new List<UsersModel>();

            foreach (DataRow row in table.Rows)
            {
                UsersModel user = new UsersModel();

                user.personId = Convert.ToInt32(row["PersonID"]);
                user.lastName = Convert.ToString(row["lastName"]);
                user.firstName = Convert.ToString(row["firstName"]);
                user.address = Convert.ToString(row["address"]);
                user.city = Convert.ToString(row["city"]);
                usersList.Add(user);
            }
            return usersList;
        }

        public void CreateNewUser(UsersModel user)
        {

            DataTable table = this.conn.executeQuery("INSERT INTO Persons VALUES ('"+ user.lastName +"', '"+user.firstName+"', '"+user.address+"', '"+user.city+"')");

        }
        public void updateUser(UsersModel user)
        {

            string query = "UPDATE Persons SET LastName='" + user.lastName + "', FirstName= '" + user.firstName + "', Address= '" + user.address + "', City='" + user.city + "' WHERE PersonID=" + user.personId;
            System.Diagnostics.Debug.WriteLine(query);
            DataTable table = this.conn.executeQuery("UPDATE Persons SET LastName='" + user.lastName + "', FirstName= '" + user.firstName + "', Address= '" + user.address + "', City='" + user.city + "' WHERE PersonID="+user.personId);

        }

        public void DeleteUser(int ID)
        {

            DataTable table = this.conn.executeQuery("DELETE FROM Persons WHERE personId ="+ID);

        }

        public UsersModel GetUser(int ID)
        {

            DataTable table = this.conn.executeQuery("SELECT * FROM Persons WHERE personId =" + ID);
            UsersModel user = new UsersModel();
           
            foreach (DataRow row in table.Rows)
	{
        user.firstName = Convert.ToString(row["firstName"]);
        user.lastName = Convert.ToString(row["lastName"]);
        user.address = Convert.ToString(row["address"]);
        user.city = Convert.ToString(row["city"]);
        user.personId = Convert.ToInt32(row["personId"]);
	}



            return user;

        }

    }
}