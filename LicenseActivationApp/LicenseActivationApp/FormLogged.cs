using System;
using System.Windows.Forms;

namespace LicenseActivationApp
{
    public partial class FormLogged : Form
    {
        DataAccess.Licenses dataLicenses = new DataAccess.Licenses();
        public int counter = 0;

        public FormLogged()
        {
            InitializeComponent();
        }

        private void FormLogged_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnCheckLicense_Click(object sender, EventArgs e)
        {
            FormLicenseMessage formLicenseMessage = new FormLicenseMessage();
            formLicenseMessage.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            if(counter == 5)
            {
                var data = new DataAccess.Licenses();
                data = dataLicenses.ValidatePurchase();
                if (dataLicenses.ValidateLicense() && data.Status == "Activated" && data.Activation > 0)
                {
                    if(data.MacAddress == dataLicenses.GetMacAddress())
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
                    FormLicenseMessage formLicenseMessage = new FormLicenseMessage();
                    formLicenseMessage.ShowDialog();
                }
                timer1.Stop();
            }
        }        
    }
}
