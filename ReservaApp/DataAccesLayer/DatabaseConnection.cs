using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
	public class DatabaseConnection : IConnection
	{
		private const string connectionString = "server=mssqlstud.fhict.local;database=dbi504835_reserva;uid=dbi504835_reserva;password=password12345;TrustServerCertificate=True;";

        public void ModifyDB(SqlCommand cmd)
        {
			
            using SqlConnection conn = new SqlConnection(connectionString);
            SqlTransaction transaction = conn.BeginTransaction();
			try
			{
                cmd.Connection = conn;
                conn.Open();
				cmd.ExecuteNonQuery();
				transaction.Commit();
                conn.Close();
            }
            catch (SqlException ex) 
			{ 
				transaction.Rollback();
                conn.Close();
                throw ex;
			}
            
        }

        public SqlDataReader GetFromDB(SqlCommand cmd)
		{
			SqlConnection conn = new SqlConnection(connectionString);
			cmd.Connection = conn;
			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader();
			return reader;
		}

       


	}
}
