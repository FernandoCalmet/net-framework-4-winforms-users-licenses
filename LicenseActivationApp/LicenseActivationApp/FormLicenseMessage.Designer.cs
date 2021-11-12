
namespace LicenseActivationApp
{
    partial class FormLicenseMessage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtActivationKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnGetLicense = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtActivationKey
            // 
            this.txtActivationKey.Location = new System.Drawing.Point(22, 46);
            this.txtActivationKey.Name = "txtActivationKey";
            this.txtActivationKey.Size = new System.Drawing.Size(331, 20);
            this.txtActivationKey.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "License Activation Key";
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(22, 83);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 2;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnGetLicense
            // 
            this.btnGetLicense.Location = new System.Drawing.Point(104, 82);
            this.btnGetLicense.Name = "btnGetLicense";
            this.btnGetLicense.Size = new System.Drawing.Size(75, 23);
            this.btnGetLicense.TabIndex = 3;
            this.btnGetLicense.Text = "Get License";
            this.btnGetLicense.UseVisualStyleBackColor = true;
            // 
            // FormLicenseMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 141);
            this.Controls.Add(this.btnGetLicense);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtActivationKey);
            this.Name = "FormLicenseMessage";
            this.Text = "FormLicenseMessage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtActivationKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnGetLicense;
    }
}