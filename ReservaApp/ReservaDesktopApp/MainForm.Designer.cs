namespace ReservaDesktopApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelMenu = new Panel();
            btnEmployee = new Button();
            btnActivity = new Button();
            btnLocationView = new Button();
            btnHotelOverview = new Button();
            panelLogo = new Panel();
            lblLogo = new Label();
            panelTitle = new Panel();
            lblTitle = new Label();
            btnCloseChildForm = new Button();
            panelDesktopPanel = new Panel();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelTitle.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(0, 11, 105);
            panelMenu.Controls.Add(btnEmployee);
            panelMenu.Controls.Add(btnActivity);
            panelMenu.Controls.Add(btnLocationView);
            panelMenu.Controls.Add(btnHotelOverview);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(4, 5, 4, 5);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(261, 825);
            panelMenu.TabIndex = 0;
            // 
            // btnEmployee
            // 
            btnEmployee.Dock = DockStyle.Top;
            btnEmployee.FlatAppearance.BorderSize = 0;
            btnEmployee.FlatStyle = FlatStyle.Flat;
            btnEmployee.Font = new Font("Segoe UI", 10F);
            btnEmployee.ForeColor = Color.Gainsboro;
            btnEmployee.Image = (Image)resources.GetObject("btnEmployee.Image");
            btnEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            btnEmployee.Location = new Point(0, 427);
            btnEmployee.Margin = new Padding(4, 5, 4, 5);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Padding = new Padding(17, 0, 0, 0);
            btnEmployee.Size = new Size(261, 100);
            btnEmployee.TabIndex = 4;
            btnEmployee.Text = "   Employees";
            btnEmployee.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEmployee.UseVisualStyleBackColor = true;
            btnEmployee.Click += btnEmployee_Click;
            // 
            // btnActivity
            // 
            btnActivity.Dock = DockStyle.Top;
            btnActivity.FlatAppearance.BorderSize = 0;
            btnActivity.FlatStyle = FlatStyle.Flat;
            btnActivity.Font = new Font("Segoe UI", 10F);
            btnActivity.ForeColor = Color.Gainsboro;
            btnActivity.Image = (Image)resources.GetObject("btnActivity.Image");
            btnActivity.ImageAlign = ContentAlignment.MiddleLeft;
            btnActivity.Location = new Point(0, 327);
            btnActivity.Margin = new Padding(4, 5, 4, 5);
            btnActivity.Name = "btnActivity";
            btnActivity.Padding = new Padding(17, 0, 0, 0);
            btnActivity.Size = new Size(261, 100);
            btnActivity.TabIndex = 3;
            btnActivity.Text = "   Activities";
            btnActivity.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnActivity.UseVisualStyleBackColor = true;
            btnActivity.Click += btnActivity_Click;
            // 
            // btnLocationView
            // 
            btnLocationView.Dock = DockStyle.Top;
            btnLocationView.FlatAppearance.BorderSize = 0;
            btnLocationView.FlatStyle = FlatStyle.Flat;
            btnLocationView.Font = new Font("Segoe UI", 10F);
            btnLocationView.ForeColor = Color.Gainsboro;
            btnLocationView.Image = (Image)resources.GetObject("btnLocationView.Image");
            btnLocationView.ImageAlign = ContentAlignment.MiddleLeft;
            btnLocationView.Location = new Point(0, 227);
            btnLocationView.Margin = new Padding(4, 5, 4, 5);
            btnLocationView.Name = "btnLocationView";
            btnLocationView.Padding = new Padding(17, 0, 0, 0);
            btnLocationView.Size = new Size(261, 100);
            btnLocationView.TabIndex = 2;
            btnLocationView.Text = "   Location";
            btnLocationView.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLocationView.UseVisualStyleBackColor = true;
            btnLocationView.Click += btnLocationView_Click;
            // 
            // btnHotelOverview
            // 
            btnHotelOverview.Dock = DockStyle.Top;
            btnHotelOverview.FlatAppearance.BorderSize = 0;
            btnHotelOverview.FlatStyle = FlatStyle.Flat;
            btnHotelOverview.Font = new Font("Segoe UI", 10F);
            btnHotelOverview.ForeColor = Color.Gainsboro;
            btnHotelOverview.Image = (Image)resources.GetObject("btnHotelOverview.Image");
            btnHotelOverview.ImageAlign = ContentAlignment.MiddleLeft;
            btnHotelOverview.Location = new Point(0, 127);
            btnHotelOverview.Margin = new Padding(4, 5, 4, 5);
            btnHotelOverview.Name = "btnHotelOverview";
            btnHotelOverview.Padding = new Padding(17, 0, 0, 0);
            btnHotelOverview.Size = new Size(261, 100);
            btnHotelOverview.TabIndex = 1;
            btnHotelOverview.Text = "   Hotel";
            btnHotelOverview.TextAlign = ContentAlignment.MiddleLeft;
            btnHotelOverview.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHotelOverview.UseVisualStyleBackColor = true;
            btnHotelOverview.Click += btnHotelOverview_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(0, 0, 64);
            panelLogo.Controls.Add(lblLogo);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(4, 5, 4, 5);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(261, 127);
            panelLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.Anchor = AnchorStyles.None;
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Script MT Bold", 21.75F, FontStyle.Bold);
            lblLogo.ForeColor = SystemColors.HighlightText;
            lblLogo.Location = new Point(47, 35);
            lblLogo.Margin = new Padding(4, 0, 4, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(166, 53);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "Reserva";
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.FromArgb(0, 11, 105);
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Controls.Add(btnCloseChildForm);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(261, 0);
            panelTitle.Margin = new Padding(4, 5, 4, 5);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1080, 127);
            panelTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(256, 13);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(576, 108);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HOME";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCloseChildForm
            // 
            btnCloseChildForm.Dock = DockStyle.Left;
            btnCloseChildForm.FlatAppearance.BorderSize = 0;
            btnCloseChildForm.FlatStyle = FlatStyle.Flat;
            btnCloseChildForm.Image = (Image)resources.GetObject("btnCloseChildForm.Image");
            btnCloseChildForm.Location = new Point(0, 0);
            btnCloseChildForm.Margin = new Padding(4, 5, 4, 5);
            btnCloseChildForm.Name = "btnCloseChildForm";
            btnCloseChildForm.Size = new Size(107, 127);
            btnCloseChildForm.TabIndex = 1;
            btnCloseChildForm.UseVisualStyleBackColor = true;
            btnCloseChildForm.Click += btnCloseChildForm_Click;
            // 
            // panelDesktopPanel
            // 
            panelDesktopPanel.Dock = DockStyle.Fill;
            panelDesktopPanel.Location = new Point(261, 127);
            panelDesktopPanel.Margin = new Padding(4, 5, 4, 5);
            panelDesktopPanel.Name = "panelDesktopPanel";
            panelDesktopPanel.Size = new Size(1080, 698);
            panelDesktopPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1341, 825);
            Controls.Add(panelDesktopPanel);
            Controls.Add(panelTitle);
            Controls.Add(panelMenu);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Main";
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelTitle.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Button btnHotelOverview;
        private Panel panelLogo;
        private Panel panelTitle;
        private Label lblTitle;
        private Label lblLogo;
        private Panel panelDesktopPanel;
        private Button btnCloseChildForm;
		private Button btnLocationView;
        private Button btnActivity;
        private Button btnEmployee;
    }
}