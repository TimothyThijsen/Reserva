namespace ReservaDesktopApp.HotelForms
{
    partial class EditHotelForm
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
            btnConfirm = new Button();
            panel1 = new Panel();
            lblPricingAlgorithm = new Label();
            cmbPricingAlgorithm = new ComboBox();
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
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(576, 600);
            btnConfirm.Margin = new Padding(4, 5, 4, 5);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(257, 78);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblPricingAlgorithm);
            panel1.Controls.Add(cmbPricingAlgorithm);
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
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 532);
            panel1.TabIndex = 4;
            // 
            // lblPricingAlgorithm
            // 
            lblPricingAlgorithm.AutoSize = true;
            lblPricingAlgorithm.Location = new Point(450, 30);
            lblPricingAlgorithm.Margin = new Padding(4, 0, 4, 0);
            lblPricingAlgorithm.Name = "lblPricingAlgorithm";
            lblPricingAlgorithm.Size = new Size(147, 25);
            lblPricingAlgorithm.TabIndex = 13;
            lblPricingAlgorithm.Text = "Pricing algorithm";
            // 
            // cmbPricingAlgorithm
            // 
            cmbPricingAlgorithm.FormattingEnabled = true;
            cmbPricingAlgorithm.Location = new Point(600, 20);
            cmbPricingAlgorithm.Margin = new Padding(4, 5, 4, 5);
            cmbPricingAlgorithm.Name = "cmbPricingAlgorithm";
            cmbPricingAlgorithm.Size = new Size(295, 33);
            cmbPricingAlgorithm.TabIndex = 12;
            // 
            // txbPostalCode
            // 
            txbPostalCode.Location = new Point(219, 153);
            txbPostalCode.MaxLength = 30;
            txbPostalCode.Name = "txbPostalCode";
            txbPostalCode.Size = new Size(183, 31);
            txbPostalCode.TabIndex = 9;
            // 
            // txbStreet
            // 
            txbStreet.Location = new Point(219, 112);
            txbStreet.MaxLength = 30;
            txbStreet.Name = "txbStreet";
            txbStreet.Size = new Size(183, 31);
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
            cmbCities.Location = new Point(219, 63);
            cmbCities.Name = "cmbCities";
            cmbCities.Size = new Size(183, 33);
            cmbCities.TabIndex = 6;
            // 
            // txbDescription
            // 
            txbDescription.Location = new Point(106, 237);
            txbDescription.MaxLength = 250;
            txbDescription.Multiline = true;
            txbDescription.Name = "txbDescription";
            txbDescription.Size = new Size(753, 272);
            txbDescription.TabIndex = 5;
            // 
            // txbName
            // 
            txbName.Location = new Point(219, 17);
            txbName.MaxLength = 50;
            txbName.Name = "txbName";
            txbName.Size = new Size(183, 31);
            txbName.TabIndex = 4;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(106, 192);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(102, 25);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description";
            // 
            // lblStreet
            // 
            lblStreet.AutoSize = true;
            lblStreet.Location = new Point(106, 113);
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
            lblName.Location = new Point(106, 18);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 25);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // button1
            // 
            button1.Location = new Point(194, 600);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(257, 78);
            button1.TabIndex = 3;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnCancel_Click;
            // 
            // EditHotelForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 698);
            Controls.Add(btnConfirm);
            Controls.Add(panel1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditHotelForm";
            Text = "EditHotelForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnConfirm;
		private Panel panel1;
		private TextBox txbPostalCode;
		private TextBox txbStreet;
		private Label lblPostalCode;
		private ComboBox cmbCities;
		private TextBox txbDescription;
		private TextBox txbName;
		private Label lblDescription;
		private Label lblStreet;
		private Label lblCity;
		private Label lblName;
		private Button button1;
        private Label lblPricingAlgorithm;
        private ComboBox cmbPricingAlgorithm;
    }
}