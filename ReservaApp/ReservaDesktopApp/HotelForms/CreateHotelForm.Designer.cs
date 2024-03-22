namespace ReservaDesktopApp.HotelForms
{
    partial class CreateHotelForm
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
            btnCancel = new Button();
            panel1 = new Panel();
            txbPostalCode = new TextBox();
            txbStreet = new TextBox();
            lblPostalCode = new Label();
            cmbCities = new ComboBox();
            txbDescription = new TextBox();
            txbName = new TextBox();
            lblDescription = new Label();
            lblStreet = new Label();
            lblCity = new Label();
            lblName = new Label();
            btnConfirm = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(118, 598);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(257, 79);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txbPostalCode);
            panel1.Controls.Add(txbStreet);
            panel1.Controls.Add(lblPostalCode);
            panel1.Controls.Add(cmbCities);
            panel1.Controls.Add(txbDescription);
            panel1.Controls.Add(txbName);
            panel1.Controls.Add(lblDescription);
            panel1.Controls.Add(lblStreet);
            panel1.Controls.Add(lblCity);
            panel1.Controls.Add(lblName);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1119, 527);
            panel1.TabIndex = 1;
            // 
            // txbPostalCode
            // 
            txbPostalCode.Location = new Point(218, 154);
            txbPostalCode.Name = "txbPostalCode";
            txbPostalCode.Size = new Size(182, 31);
            txbPostalCode.TabIndex = 9;
            // 
            // txbStreet
            // 
            txbStreet.Location = new Point(218, 111);
            txbStreet.Name = "txbStreet";
            txbStreet.Size = new Size(182, 31);
            txbStreet.TabIndex = 8;
            // 
            // lblPostalCode
            // 
            lblPostalCode.AutoSize = true;
            lblPostalCode.Location = new Point(106, 157);
            lblPostalCode.Name = "lblPostalCode";
            lblPostalCode.Size = new Size(103, 25);
            lblPostalCode.TabIndex = 7;
            lblPostalCode.Text = "Postal code";
            // 
            // cmbCities
            // 
            cmbCities.FormattingEnabled = true;
            cmbCities.Location = new Point(218, 63);
            cmbCities.Name = "cmbCities";
            cmbCities.Size = new Size(182, 33);
            cmbCities.TabIndex = 6;
            // 
            // txbDescription
            // 
            txbDescription.Location = new Point(106, 236);
            txbDescription.Multiline = true;
            txbDescription.Name = "txbDescription";
            txbDescription.Size = new Size(753, 273);
            txbDescription.TabIndex = 5;
            // 
            // txbName
            // 
            txbName.Location = new Point(218, 16);
            txbName.Name = "txbName";
            txbName.Size = new Size(182, 31);
            txbName.TabIndex = 4;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(106, 191);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(102, 25);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description";
            // 
            // lblStreet
            // 
            lblStreet.AutoSize = true;
            lblStreet.Location = new Point(106, 114);
            lblStreet.Name = "lblStreet";
            lblStreet.Size = new Size(57, 25);
            lblStreet.TabIndex = 2;
            lblStreet.Text = "Street";
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(106, 63);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(42, 25);
            lblCity.TabIndex = 1;
            lblCity.Text = "City";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(106, 19);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 25);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(630, 598);
            btnConfirm.Margin = new Padding(4, 5, 4, 5);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(257, 79);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // CreateHotelForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(btnConfirm);
            Controls.Add(panel1);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "CreateHotelForm";
            Text = "CreateHotel";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCancel;
        private Panel panel1;
        private Label lblDescription;
        private Label lblStreet;
        private Label lblCity;
        private Label lblName;
        private TextBox txbDescription;
        private TextBox txbName;
        private ComboBox cmbCities;
        private Label lblPostalCode;
        private TextBox txbPostalCode;
        private TextBox txbStreet;
        private Button btnConfirm;
    }
}