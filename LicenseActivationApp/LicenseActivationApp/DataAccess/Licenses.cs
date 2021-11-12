using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace LicenseActivationApp.DataAccess
{
    public class Licenses : MasterRepository
    {
        public int Activation { get; set; }
        public string Status { get; set; }
        public string MacAddress { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string LicenseKey { get; set; }
        public int UserId { get; set; }

        public Licenses ValidatePurchase()
        {
            string command = "SELECT * FROM acquired_license WHERE user_id = @p_user_id";
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@p_user_id", Cache.UserCache.UserId));
            var reader = ExecuteReader(command);
            var licenses = new Licenses();
            foreach (DataRow item in reader.Rows)
            {
                licenses.Activation = Convert.ToInt32(item[0]);
                licenses.Status = item[1].ToString();
                licenses.MacAddress = item[2].ToString();
                licenses.PurchaseDate = Convert.ToDateTime(item[3]);
                licenses.ExpirationDate = Convert.ToDateTime(item[4]);
                licenses.LicenseKey = item[5].ToString();
                licenses.UserId = Convert.ToInt32(item[6]);

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
            ExecuteNonQuery(command);

            return "License Activated Successfully";
        }

        public bool ValidateLicense()
        {
            string command = "SELECT * FROM acquired_license al INNER JOIN license l ON l.id = al.license_id WHERE al.user_id = @p_user_id AND l.key = @p_license_key";
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@p_user_id", Cache.UserCache.UserId));
            parameters.Add(new SqlParameter("@p_license_key", LicenseKey));
            return LicenseValidation(command);
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
