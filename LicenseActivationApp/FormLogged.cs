using System;
using System.Windows.Forms;

namespace LicenseActivationApp
{
    public partial class FormLogged : Form
    {
        DataAccess.Licenses data = new DataAccess.Licenses();
        public int counter = 0;

        public FormLogged()
        {
            InitializeComponent();
            lblId.Text = Convert.ToString(Cache.UserCache.UserId);
            lblUsername.Text = Cache.UserCache.UserName;
        }

        private void FormLogged_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnCheckLicense_Click(object sender, EventArgs e)
        {
            FormLicenseMessage formLicenseMessage = new FormLicenseMessage(data);
            formLicenseMessage.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            if(counter == 5)
            {
                data = data.PurchasedLicense();
                if (data.ValidateLicense() && data.Status == "Activated" && data.Activation > 0)
                {
                    if (data.MacAddress == data.GetMacAddress())
                    {
                        MessageBox.Show("License Activated OK!");
                    }
                    else
                    {
                        MessageBox.Show("Sorry your license is not activated!");
                    }
                }
                else
                {
                    FormLicenseMessage formLicenseMessage = new FormLicenseMessage(data);
                    formLicenseMessage.ShowDialog();
                }
                timer1.Stop();
            }
        }        
    }
}
