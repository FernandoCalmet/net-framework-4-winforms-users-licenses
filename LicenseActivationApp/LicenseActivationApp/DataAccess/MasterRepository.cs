using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LicenseActivationApp.DataAccess
{
    public abstract class MasterRepository : Repository
    {
        protected List<SqlParameter> parameters;
        private DataTable dataTable;

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

        protected void ExecuteNonQuery(string commandText, List<SqlParameter> parameters)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = commandText;
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddRange(parameters.ToArray());
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

        protected DataTable ExecuteReader(string commandText, List<SqlParameter> parameters)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = commandText;
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddRange(parameters.ToArray());
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

        protected DataTable ExecuteReader(string commandText, List<SqlParameter> parameters, CommandType commandType)
        {
            dataTable = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = commandText;
                    command.CommandType = commandType;
                    command.Parameters.AddRange(parameters.ToArray());
                    using (var reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;
        }

        protected bool LicenseValidation(string commandText, List<SqlParameter> parameters)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = commandText;
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddRange(parameters.ToArray());
                    //foreach (SqlParameter param in parameters)
                    //{
                    //    command.Parameters.Add(param);
                    //}
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
