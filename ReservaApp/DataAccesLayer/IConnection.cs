using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public interface IConnection
    {
        public void ModifyDB(SqlCommand cmd);
        public SqlDataReader GetFromDB(SqlCommand cmd);
    }
}
