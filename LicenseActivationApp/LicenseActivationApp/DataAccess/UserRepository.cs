using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LicenseActivationApp.DataAccess
{
    public class UserRepository : MasterRepository, IUserRepository
    {
        public bool Login(string username, string password)
        {
            string commandText = "SELECT * FROM user WHERE @username = username AND @password = password";
            CommandType commandType = CommandType.Text;
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@username", username));
            parameters.Add(new SqlParameter("@password", password));
            var table = ExecuteReader(commandText, parameters, commandType);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    Cache.UserCache.UserId = (int)(row[0]);
                    Cache.UserCache.UserName = row[1].ToString();
                    Cache.UserCache.Password = row[2].ToString();
                }
                return true;
            }
            else
                return false;
        }
    }
}
