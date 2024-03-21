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
            btnHotelOverview = new Button();
            panelLogo = new Panel();
            lblLogo = new Label();
            panelTitle = new Panel();
            btnCloseChildForm = new Button();
            lblTitle = new Label();
            panelDesktopPanel = new Panel();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelTitle.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(0, 11, 105);
            panelMenu.Controls.Add(btnHotelOverview);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(183, 495);
            panelMenu.TabIndex = 0;
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
            btnHotelOverview.Location = new Point(0, 76);
            btnHotelOverview.Name = "btnHotelOverview";
            btnHotelOverview.Padding = new Padding(12, 0, 0, 0);
            btnHotelOverview.Size = new Size(183, 60);
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
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(183, 76);
            panelLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.Anchor = AnchorStyles.None;
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Script MT Bold", 21.75F, FontStyle.Bold);
            lblLogo.ForeColor = SystemColors.HighlightText;
            lblLogo.Location = new Point(33, 21);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(111, 35);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "Reserva";
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.FromArgb(0, 11, 105);
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Controls.Add(btnCloseChildForm);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(183, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(756, 76);
            panelTitle.TabIndex = 1;
            // 
            // btnCloseChildForm
            // 
            btnCloseChildForm.Dock = DockStyle.Left;
            btnCloseChildForm.FlatAppearance.BorderSize = 0;
            btnCloseChildForm.FlatStyle = FlatStyle.Flat;
            btnCloseChildForm.Image = (Image)resources.GetObject("btnCloseChildForm.Image");
            btnCloseChildForm.Location = new Point(0, 0);
            btnCloseChildForm.Name = "btnCloseChildForm";
            btnCloseChildForm.Size = new Size(75, 76);
            btnCloseChildForm.TabIndex = 1;
            btnCloseChildForm.UseVisualStyleBackColor = true;
            btnCloseChildForm.Click += btnCloseChildForm_Click;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(179, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(403, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HOME";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelDesktopPanel
            // 
            panelDesktopPanel.Dock = DockStyle.Fill;
            panelDesktopPanel.Location = new Point(183, 76);
            panelDesktopPanel.Name = "panelDesktopPanel";
            panelDesktopPanel.Size = new Size(756, 419);
            panelDesktopPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 495);
            Controls.Add(panelDesktopPanel);
            Controls.Add(panelTitle);
            Controls.Add(panelMenu);
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
    }
}