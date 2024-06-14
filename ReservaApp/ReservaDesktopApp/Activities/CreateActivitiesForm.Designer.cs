namespace ReservaDesktopApp.Activities
{
    partial class CreateActivitiesForm
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
            nmrCapacity = new NumericUpDown();
            nmrPrice = new NumericUpDown();
            lblCapacity = new Label();
            lblPrice = new Label();
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
            btnCancel = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmrCapacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmrPrice).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(nmrCapacity);
            panel1.Controls.Add(nmrPrice);
            panel1.Controls.Add(lblCapacity);
            panel1.Controls.Add(lblPrice);
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
            panel1.Size = new Size(1080, 527);
            panel1.TabIndex = 2;
            // 
            // nmrCapacity
            // 
            nmrCapacity.Location = new Point(634, 61);
            nmrCapacity.Margin = new Padding(4, 5, 4, 5);
            nmrCapacity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nmrCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmrCapacity.Name = "nmrCapacity";
            nmrCapacity.Size = new Size(171, 31);
            nmrCapacity.TabIndex = 15;
            nmrCapacity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nmrPrice
            // 
            nmrPrice.DecimalPlaces = 2;
            nmrPrice.Location = new Point(634, 16);
            nmrPrice.Margin = new Padding(4, 5, 4, 5);
            nmrPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nmrPrice.Name = "nmrPrice";
            nmrPrice.Size = new Size(171, 31);
            nmrPrice.TabIndex = 14;
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Location = new Point(521, 63);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(79, 25);
            lblCapacity.TabIndex = 12;
            lblCapacity.Text = "Capacity";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(521, 20);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(49, 25);
            lblPrice.TabIndex = 10;
            lblPrice.Text = "Price";
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
            cmbCities.DropDownStyle = ComboBoxStyle.DropDownList;
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
            txbDescription.Size = new Size(730, 272);
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
            // btnConfirm
            // 
            btnConfirm.Location = new Point(599, 565);
            btnConfirm.Margin = new Padding(4, 5, 4, 5);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(257, 78);
            btnConfirm.TabIndex = 4;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(186, 565);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(257, 78);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // CreateActivitiesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 698);
            Controls.Add(btnConfirm);
            Controls.Add(btnCancel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CreateActivitiesForm";
            Text = "CreateActivitiesForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmrCapacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmrPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion

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
        private Button btnConfirm;
        private Button btnCancel;
        private Label lblCapacity;
        private Label lblPrice;
        private NumericUpDown nmrCapacity;
        private NumericUpDown nmrPrice;
    }
}