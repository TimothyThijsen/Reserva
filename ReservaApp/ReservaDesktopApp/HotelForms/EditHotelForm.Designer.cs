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
			btnConfirm.Location = new Point(403, 360);
			btnConfirm.Name = "btnConfirm";
			btnConfirm.Size = new Size(180, 47);
			btnConfirm.TabIndex = 5;
			btnConfirm.Text = "Confirm";
			btnConfirm.UseVisualStyleBackColor = true;
			btnConfirm.Click += btnConfirm_Click;
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
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(0, 0);
			panel1.Margin = new Padding(2);
			panel1.Name = "panel1";
			panel1.Size = new Size(756, 319);
			panel1.TabIndex = 4;
			// 
			// txbPostalCode
			// 
			txbPostalCode.Location = new Point(153, 92);
			txbPostalCode.Margin = new Padding(2);
			txbPostalCode.Name = "txbPostalCode";
			txbPostalCode.Size = new Size(129, 23);
			txbPostalCode.TabIndex = 9;
			// 
			// txbStreet
			// 
			txbStreet.Location = new Point(153, 67);
			txbStreet.Margin = new Padding(2);
			txbStreet.Name = "txbStreet";
			txbStreet.Size = new Size(129, 23);
			txbStreet.TabIndex = 8;
			// 
			// lblPostalCode
			// 
			lblPostalCode.AutoSize = true;
			lblPostalCode.Location = new Point(74, 94);
			lblPostalCode.Margin = new Padding(2, 0, 2, 0);
			lblPostalCode.Name = "lblPostalCode";
			lblPostalCode.Size = new Size(68, 15);
			lblPostalCode.TabIndex = 7;
			lblPostalCode.Text = "Postal code";
			// 
			// cmbCities
			// 
			cmbCities.FormattingEnabled = true;
			cmbCities.Location = new Point(153, 38);
			cmbCities.Margin = new Padding(2);
			cmbCities.Name = "cmbCities";
			cmbCities.Size = new Size(129, 23);
			cmbCities.TabIndex = 6;
			// 
			// txbDescription
			// 
			txbDescription.Location = new Point(74, 142);
			txbDescription.Margin = new Padding(2);
			txbDescription.Multiline = true;
			txbDescription.Name = "txbDescription";
			txbDescription.Size = new Size(528, 165);
			txbDescription.TabIndex = 5;
			// 
			// txbName
			// 
			txbName.Location = new Point(153, 10);
			txbName.Margin = new Padding(2);
			txbName.Name = "txbName";
			txbName.Size = new Size(129, 23);
			txbName.TabIndex = 4;
			// 
			// lblDescription
			// 
			lblDescription.AutoSize = true;
			lblDescription.Location = new Point(74, 115);
			lblDescription.Margin = new Padding(2, 0, 2, 0);
			lblDescription.Name = "lblDescription";
			lblDescription.Size = new Size(67, 15);
			lblDescription.TabIndex = 3;
			lblDescription.Text = "Description";
			// 
			// lblStreet
			// 
			lblStreet.AutoSize = true;
			lblStreet.Location = new Point(74, 68);
			lblStreet.Margin = new Padding(2, 0, 2, 0);
			lblStreet.Name = "lblStreet";
			lblStreet.Size = new Size(37, 15);
			lblStreet.TabIndex = 2;
			lblStreet.Text = "Street";
			// 
			// lblCity
			// 
			lblCity.AutoSize = true;
			lblCity.Location = new Point(74, 38);
			lblCity.Margin = new Padding(2, 0, 2, 0);
			lblCity.Name = "lblCity";
			lblCity.Size = new Size(28, 15);
			lblCity.TabIndex = 1;
			lblCity.Text = "City";
			// 
			// lblName
			// 
			lblName.AutoSize = true;
			lblName.Location = new Point(74, 11);
			lblName.Margin = new Padding(2, 0, 2, 0);
			lblName.Name = "lblName";
			lblName.Size = new Size(39, 15);
			lblName.TabIndex = 0;
			lblName.Text = "Name";
			// 
			// button1
			// 
			button1.Location = new Point(136, 360);
			button1.Name = "button1";
			button1.Size = new Size(180, 47);
			button1.TabIndex = 3;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = true;
			button1.Click += btnCancel_Click;
			// 
			// EditHotelForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(756, 419);
			Controls.Add(btnConfirm);
			Controls.Add(panel1);
			Controls.Add(button1);
			FormBorderStyle = FormBorderStyle.None;
			Margin = new Padding(2, 2, 2, 2);
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
	}
}