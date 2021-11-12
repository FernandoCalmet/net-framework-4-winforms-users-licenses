using System;
using System.Windows.Forms;

namespace LicenseActivationApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cache.UserCache.UserId = 1;
            Cache.UserCache.UserName = "Fernando";
            this.Hide();
            FormLogged formLogged = new FormLogged();
            formLogged.Show();
        }
    }
}
