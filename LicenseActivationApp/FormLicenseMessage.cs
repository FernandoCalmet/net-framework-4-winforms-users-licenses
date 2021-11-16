using System;
using System.Windows.Forms;

namespace LicenseActivationApp
{
    public partial class FormLicenseMessage : Form
    {
        DataAccess.Licenses data;

        public FormLicenseMessage(DataAccess.Licenses data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            data.LicenseKey = txtActivationKey.Text;
            if (data.ValidateLicense())
            {
                data.Status = "Activated";
                data.MacAddress = data.GetMacAddress();
                MessageBox.Show(data.ActivateLicense());
            }
            else
            {
                MessageBox.Show("The License Key is not valid.");
            }
        }
    }
}
