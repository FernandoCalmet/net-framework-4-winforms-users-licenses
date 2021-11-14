using System;
using System.Windows.Forms;

namespace LicenseActivationApp
{
    public partial class FormLogin : Form
    {
        private string usernamePlaceholder;
        private string passwordPlaceholder;
        public FormLogin()
        {
            InitializeComponent();
            usernamePlaceholder = txtUsername.Text;
            passwordPlaceholder = txtPassword.Text;
        }

        private void SetPlaceHolder()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = usernamePlaceholder;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = passwordPlaceholder;
            }
        }

        private void RemovePlaceHolder(TextBox textBox, string placeholderText)
        {
            if (textBox.Text == placeholderText)
            {
                textBox.Text = "";
                if (textBox == txtPassword)
                    textBox.UseSystemPasswordChar = true;
            }
        }

        private void Login()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.Text == usernamePlaceholder)
            {
                MessageBox.Show("Enter username or email");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text == passwordPlaceholder)
            {
                MessageBox.Show("Enter password");
                return;
            }

            Cache.UserCache.UserId = 1;
            Cache.UserCache.UserName = txtUsername.Text;
            Cache.UserCache.Password = txtPassword.Text;
            this.Hide();
            FormLogged formLogged = new FormLogged();
            formLogged.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}
