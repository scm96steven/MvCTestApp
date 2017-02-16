using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;



namespace DataLayer
{
    public class Connection
    {

        public OracleConnection conn = new OracleConnection();
        string connectionString;

       public void setConnectionString(string dbValue)
        {
            if (dbValue.Equals("RD"))
            {
                this.conn.ConnectionString = "Data source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 01DR4ORACLEDB.CSID.LOCAL)(PORT = 1521))(CONNECT_DATA =(SERVICE_NAME = DIMMASYP.01DR4ORACLEDB.CSID.LOCAL)));User ID=RUSER;Password=RU321;";
            }

            if (dbValue.Equals("PR"))
            {
                this.conn.ConnectionString = "Data source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 172.27.136.218)(PORT = 1521))(CONNECT_DATA =(SERVICE_NAME = DIMMASYP_AXESA)));User ID=YBRDS_PROD;Password=YBRDS_PROD;";
            }
            if (dbValue.Equals("MadaschiAzure"))
            {
                this.conn.ConnectionString = "Data source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = madaschidb.database.windows.net)(PORT = 1433)));User ID=scm96steven;Password=p@ssw0rd;";
            }

           
           }


     

     
       public Connection()
        {
          
         
        }

        public OracleConnection GetConnection()
        {
            
            return this.conn;
        }


        public DataTable executeQuery(string query)
        {


            OracleCommand command = this.conn.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
        
        
            conn.Open();
            System.Diagnostics.Debug.WriteLine("State: {0}", conn.State);
            System.Diagnostics.Debug.WriteLine("ConnectionString: {0}", conn.ConnectionString);
         
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
                */ //Esto funciona para procedures que reciben valores de entrada

             
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




      
    }
}
