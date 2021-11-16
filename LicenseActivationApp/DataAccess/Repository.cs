using System.Data.SqlClient;

namespace LicenseActivationApp.DataAccess
{
    public abstract class Repository
    {
        private readonly string connectionString;

        public Repository()
        {
            //connectionString = @"Data Source=(localdb)\\mssqllocaldb;Initial Catalog=LicensesDB;Integrated Security=true";
            connectionString = @"Data Source=DESKTOP-HOQ564O\KHANAKAT;Initial Catalog=LicensesDB;Integrated Security=true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
