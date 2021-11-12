using System.Data.SqlClient;

namespace LicenseActivationApp.DataAccess
{
    public abstract class Repository
    {
        private readonly string connectionString;

        public Repository()
        {
            connectionString = @"Data Source=(localdb)\\mssqllocaldb;Initial Catalog=LicenseDB;Integrated Security=true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
