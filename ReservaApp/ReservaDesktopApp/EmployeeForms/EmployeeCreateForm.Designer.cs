namespace ReservaDesktopApp.EmployeeForms
{
    partial class EmployeeCreateForm
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
            panel1 = new Panel();
            txbPassword = new TextBox();
            label4 = new Label();
            cmbRole = new ComboBox();
            label3 = new Label();
            nmrSalary = new NumericUpDown();
            dtpDateOfbirth = new DateTimePicker();
            txbEmail = new TextBox();
            label2 = new Label();
            txbLName = new TextBox();
            label1 = new Label();
            txbPhoneNumber = new TextBox();
            lblPostalCode = new Label();
            txbFName = new TextBox();
            lblDOB = new Label();
            lblStreet = new Label();
            lblName = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmrSalary).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txbPassword);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cmbRole);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(nmrSalary);
            panel1.Controls.Add(dtpDateOfbirth);
            panel1.Controls.Add(txbEmail);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txbLName);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txbPhoneNumber);
            panel1.Controls.Add(lblPostalCode);
            panel1.Controls.Add(txbFName);
            panel1.Controls.Add(lblDOB);
            panel1.Controls.Add(lblStreet);
            panel1.Controls.Add(lblName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 527);
            panel1.TabIndex = 3;
            // 
            // txbPassword
            // 
            txbPassword.Location = new Point(640, 107);
            txbPassword.MaxLength = 50;
            txbPassword.Name = "txbPassword";
            txbPassword.PasswordChar = '*';
            txbPassword.Size = new Size(183, 31);
            txbPassword.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(527, 108);
            label4.Name = "label4";
            label4.Size = new Size(87, 25);
            label4.TabIndex = 18;
            label4.Text = "Password";
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { " administrator", " hr" });
            cmbRole.Location = new Point(307, 251);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(182, 33);
            cmbRole.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(175, 254);
            label3.Name = "label3";
            label3.Size = new Size(46, 25);
            label3.TabIndex = 16;
            label3.Text = "Role";
            // 
            // nmrSalary
            // 
            nmrSalary.DecimalPlaces = 2;
            nmrSalary.Location = new Point(306, 210);
            nmrSalary.Name = "nmrSalary";
            nmrSalary.Size = new Size(180, 31);
            nmrSalary.TabIndex = 15;
            // 
            // dtpDateOfbirth
            // 
            dtpDateOfbirth.Location = new Point(306, 292);
            dtpDateOfbirth.Name = "dtpDateOfbirth";
            dtpDateOfbirth.Size = new Size(220, 31);
            dtpDateOfbirth.TabIndex = 14;
            // 
            // txbEmail
            // 
            txbEmail.Location = new Point(306, 111);
            txbEmail.MaxLength = 50;
            txbEmail.Name = "txbEmail";
            txbEmail.Size = new Size(183, 31);
            txbEmail.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(180, 110);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 12;
            label2.Text = "Email";
            // 
            // txbLName
            // 
            txbLName.Location = new Point(640, 62);
            txbLName.MaxLength = 50;
            txbLName.Name = "txbLName";
            txbLName.Size = new Size(183, 31);
            txbLName.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(527, 63);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 10;
            label1.Text = "Last name";
            // 
            // txbPhoneNumber
            // 
            txbPhoneNumber.Location = new Point(306, 158);
            txbPhoneNumber.MaxLength = 30;
            txbPhoneNumber.Name = "txbPhoneNumber";
            txbPhoneNumber.Size = new Size(183, 31);
            txbPhoneNumber.TabIndex = 8;
            // 
            // lblPostalCode
            // 
            lblPostalCode.AutoSize = true;
            lblPostalCode.Location = new Point(179, 207);
            lblPostalCode.Name = "lblPostalCode";
            lblPostalCode.Size = new Size(59, 25);
            lblPostalCode.TabIndex = 7;
            lblPostalCode.Text = "Salary";
            // 
            // txbFName
            // 
            txbFName.Location = new Point(306, 63);
            txbFName.MaxLength = 50;
            txbFName.Name = "txbFName";
            txbFName.Size = new Size(183, 31);
            txbFName.TabIndex = 4;
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.Location = new Point(175, 297);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(113, 25);
            lblDOB.TabIndex = 3;
            lblDOB.Text = "Date of birth";
            // 
            // lblStreet
            // 
            lblStreet.AutoSize = true;
            lblStreet.Location = new Point(180, 157);
            lblStreet.Name = "lblStreet";
            lblStreet.Size = new Size(127, 25);
            lblStreet.TabIndex = 2;
            lblStreet.Text = "PhoneNumber";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(180, 62);
            lblName.Name = "lblName";
            lblName.Size = new Size(94, 25);
            lblName.TabIndex = 0;
            lblName.Text = "First name";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(582, 566);
            btnConfirm.Margin = new Padding(4, 5, 4, 5);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(257, 78);
            btnConfirm.TabIndex = 6;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(169, 566);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(257, 78);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // EmployeeCreateForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 698);
            Controls.Add(btnConfirm);
            Controls.Add(btnCancel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EmployeeCreateForm";
            Text = "Create Employee";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmrSalary).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txbPhoneNumber;
        private Label lblPostalCode;
        private TextBox txbFName;
        private Label lblDOB;
        private Label lblStreet;
        private Label lblName;
        private Button btnConfirm;
        private Button btnCancel;
        private DateTimePicker dtpDateOfbirth;
        private TextBox txbEmail;
        private Label label2;
        private TextBox txbLName;
        private Label label1;
        private NumericUpDown nmrSalary;
        private Label label3;
        private ComboBox cmbRole;
        private TextBox txbPassword;
        private Label label4;
    }
}