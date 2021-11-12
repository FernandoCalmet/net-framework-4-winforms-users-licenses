using System;
using System.Windows.Forms;

namespace LicenseActivationApp
{
    public partial class FormLicenseMessage : Form
    {
        DataAccess.Licenses dataLicenses = new DataAccess.Licenses();

        public FormLicenseMessage()
        {
            InitializeComponent();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            dataLicenses.LicenseKey = txtActivationKey.Text;
            if (dataLicenses.ValidateLicense())
            {
                dataLicenses.Status = "Activated";
                dataLicenses.MacAddress = dataLicenses.GetMacAddress();
                MessageBox.Show(dataLicenses.ActivateLicense());
            }
            else
            {
                MessageBox.Show("The License Key is not valid.");
            }
        }
    }
}
