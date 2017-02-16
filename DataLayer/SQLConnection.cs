using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace DataLayer
{
    public class SQLConnection
    {

        public SqlConnection conn = new SqlConnection();
        string connectionString;

       public void setConnectionString(string dbValue)
        {
            if (dbValue.Equals("RD"))
            {
                this.connectionString = "Data source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 01DR4ORACLEDB.CSID.LOCAL)(PORT = 1521))(CONNECT_DATA =(SERVICE_NAME = DIMMASYP.01DR4ORACLEDB.CSID.LOCAL)));User ID=RUSER;Password=RU321;";
            }

            if (dbValue.Equals("PR"))
            {
                this.connectionString = "Data source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 172.27.136.218)(PORT = 1521))(CONNECT_DATA =(SERVICE_NAME = DIMMASYP_AXESA)));User ID=YBRDS_PROD;Password=YBRDS_PROD;";
            }
            if (dbValue.Equals("MadaschiAzure"))
            {
                this.connectionString = "Data Source=madaschidb.database.windows.net;Initial Catalog=Madaschi;Persist Security Info=True;User ID=scm96steven;Password=p@ssw0rd";
                   
            }

           
           }


     

     
       public SQLConnection()
        {
          
         
        }

        public SqlConnection GetConnection()
        {
            
            return this.conn;
        }


        public DataTable executeQuery(string query)
        {


            SqlCommand command = this.conn.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            conn.ConnectionString = this.connectionString;
            conn.Open();
            System.Diagnostics.Debug.WriteLine("State: {0}", conn.State);
            System.Diagnostics.Debug.WriteLine("ConnectionString: {0}", conn.ConnectionString);
         
            DataTable table = new DataTable();
            SqlDataReader reader;
            try
            {
                reader = command.ExecuteReader();
                table.Load(reader);
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Record is not inserted into the database table.");
                System.Diagnostics.Debug.WriteLine("Exception Message: " + ex.Message);
                System.Diagnostics.Debug.WriteLine("Exception Source: " + ex.Source);
            }

            conn.Close();
            return table;
        }


        /*
              public DataTable executeProcedure(string sp)
        {


            OracleCommand command = this.conn.CreateCommand();
            command.CommandText = sp;
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            System.Diagnostics.Debug.WriteLine("State: {0}", conn.State);
            System.Diagnostics.Debug.WriteLine("ConnectionString: {0}", conn.ConnectionString);
             /*
             OracleParameter subscrId = new OracleParameter();
             subscrId.ParameterName = "INT_SUBSCR_ID";
             subscrId.Value = 12712;
             command.Parameters.Add(subscrId);
              command.ExecuteNonQuery();
                 //Esto funciona para procedures que reciben valores de entrada

             
             OracleParameter cursor = new OracleParameter();
             cursor.ParameterName = "db_cursor";
             cursor.Direction = ParameterDirection.Output;
             cursor.OracleDbType = OracleDbType.RefCursor;
             command.Parameters.Add(cursor);

             
             
          
            DataTable table = new DataTable();
            OracleDataReader reader;
            try
            {
               reader = command.ExecuteReader();
               table.Load(reader);
            }
            catch (OracleException ex)
            {
                System.Diagnostics.Debug.WriteLine("Record is not inserted into the database table.");
                System.Diagnostics.Debug.WriteLine("Exception Message: " + ex.Message);
                System.Diagnostics.Debug.WriteLine("Exception Source: " + ex.Source);
            }

            conn.Close();

            return table;
        }

*/


      
    }
}
