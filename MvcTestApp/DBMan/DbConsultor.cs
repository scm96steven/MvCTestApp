using MvcTestApp.Models.Models;
using MvcTestApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcTestApp.DBMan
{
    public class DbConsultor
    {
        public DataLayer.Connection conn;

        public DbConsultor()
        {
            conn = new DataLayer.Connection();    
        }

        public List<SubscriberViewModel> getSubsList()
        {
           this.conn.setConnectionString("RD");
            DataTable table = this.conn.executeProcedure("sp_get_subscribers");
            List<SubscriberViewModel> subs_list = new List<SubscriberViewModel>();

            foreach (DataRow row in table.Rows)
            {
                
                SubscriberViewModel sub = new SubscriberViewModel();
                sub.name = Convert.ToString(row["MAIN_NAME"]);
                sub.id = Convert.ToInt32(row["SUBSCR_ID"]);
                subs_list.Add(sub);

            }
            
            return subs_list;
        }

        public List<CityViewModel> getCityList()
        {
            this.conn.setConnectionString("RD");
            DataTable table = this.conn.executeQuery("SELECT CITY, CITY_CODE FROM YBRDS_PROD.CITY ORDER BY CITY ");
            List<CityViewModel> cityList = new List<CityViewModel>();

            foreach (DataRow row in table.Rows)
            {
                CityViewModel city = new CityViewModel();
                city.name = Convert.ToString(row["CITY"]);
                city.city_code = Convert.ToString(row["CITY_CODE"]);
                cityList.Add(city);
            }
            return cityList;
        }

        public List<CityViewModel> ifCityExists(string cityName)
        {


            DataTable table = this.conn.executeQuery("SELECT CITY, CITY_CODE FROM YBRDS_PROD.CITY WHERE lower(CITY) LIKE "+"lower('%"+cityName+"%')");
            List<CityViewModel> cityList = new List<CityViewModel>();


            foreach (DataRow row in table.Rows)
            {
                CityViewModel city = new CityViewModel();
                city.name = Convert.ToString(row["CITY"]);
                city.city_code = Convert.ToString(row["CITY_CODE"]);
                cityList.Add(city);
            }
            return cityList;

        }


      

    }
}