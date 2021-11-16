using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace LicenseActivationApp.DataAccess
{
    public class Licenses : MasterRepository
    {
        public int Id { get; set; }
        public int Activation { get; set; }
        public string Status { get; set; }
        public string MacAddress { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int LicenseId { get; set; }
        public string LicenseKey { get; set; }
        public int UserId { get; set; }

        public bool ValidatePurchase()
        {
            string command = "SELECT * FROM acquired_license WHERE user_id = @p_user_id";
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@p_user_id", Cache.UserCache.UserId));
            return LicenseValidation(command, parameters);
        }

        public Licenses PurchasedLicense()
        {
            string commandText = "SELECT al.id, al.activation, al.status, al.mac_address, al.purchase_date, al.expiration_date, al.license_id, l.[key], al.user_id " +
                "FROM acquired_license al " +
                "INNER JOIN license l ON l.id = al.license_id " +
                "WHERE al.user_id = @p_user_id";
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@p_user_id", Cache.UserCache.UserId));
            var reader = ExecuteReader(commandText, parameters);
            var licenses = new Licenses();
            foreach (DataRow item in reader.Rows)
            {
                licenses.Id = Convert.ToInt32(item[0]);
                licenses.Activation = Convert.ToInt32(item[1]);
                licenses.Status = item[2].ToString();
                licenses.MacAddress = item[3].ToString();
                licenses.PurchaseDate = Convert.ToDateTime(item[4]);
                licenses.ExpirationDate = Convert.ToDateTime(item[5]);
                licenses.LicenseId = Convert.ToInt32(item[6]);
                licenses.LicenseKey = item[7].ToString();
                licenses.UserId = Convert.ToInt32(item[8]);
            }
            return licenses;
        }

        public string ActivateLicense()
        {
            string command = "UPDATE acquired_license SET activation = (activation + 1), status = @p_status, mac_address = @p_mac_address WHERE user_id = @p_user_id";
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@p_user_id", Cache.UserCache.UserId));
            parameters.Add(new SqlParameter("@p_status", Status));
            parameters.Add(new SqlParameter("@p_mac_address", MacAddress));
            ExecuteNonQuery(command, parameters);

            return "License Activated Successfully";
        }

        public bool ValidateLicense()
        {
            string command = "SELECT al.id, al.activation, al.status, al.mac_address, al.purchase_date, al.expiration_date, al.license_id, l.[key], al.user_id " +
                "FROM acquired_license al " +
                "INNER JOIN license l ON l.id = al.license_id " +
                "WHERE al.user_id = @p_user_id AND l.[key] = @p_license_key";
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@p_user_id", Cache.UserCache.UserId));
            parameters.Add(new SqlParameter("@p_license_key", LicenseKey));
            return LicenseValidation(command, parameters);
        }

        public string GetMacAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
    }
}
