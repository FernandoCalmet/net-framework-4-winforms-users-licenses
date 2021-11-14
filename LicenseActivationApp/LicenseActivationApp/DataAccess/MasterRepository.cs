using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LicenseActivationApp.DataAccess
{
    public abstract class MasterRepository : Repository
    {
        protected List<SqlParameter> parameters;

        public bool Login(string username, string password)
        {
            string commandText = "SELECT * FROM user WHERE @username = username AND @password = password";
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@username", username));
            parameters.Add(new SqlParameter("@password", password));
            var table = ExecuteReader(commandText, parameters);
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

        protected void ExecuteNonQuery(string commandText)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = commandText;
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    parameters.Clear();
                }
            }
        }

        protected DataTable ExecuteReader(string commandText)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = commandText;
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    using (var dataTable = new DataTable())
                    {
                        dataTable.Load(reader);
                        reader.Dispose();
                        return dataTable;
                    }
                }
            }
        }

        protected DataTable ExecuteReader(string commandText, List<SqlParameter> paremeters)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = commandText;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(parameters);
                    SqlDataReader reader = command.ExecuteReader();
                    using (var dataTable = new DataTable())
                    {
                        dataTable.Load(reader);
                        reader.Dispose();
                        return dataTable;
                    }
                }
            }
        }

        protected bool LicenseValidation(string commandText)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = commandText;
                    command.CommandType = CommandType.Text;
                    foreach (SqlParameter param in parameters)
                    {
                        command.Parameters.Add(param);
                    }
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                    else
                        return false;
                }
            }
        }
    }
}
