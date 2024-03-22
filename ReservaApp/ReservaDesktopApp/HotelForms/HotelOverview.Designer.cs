namespace ReservaDesktopApp.HotelForms
{
    partial class HotelOverview
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
            lvHotelDisplay = new ListView();
            clhId = new ColumnHeader();
            clhName = new ColumnHeader();
            clhRating = new ColumnHeader();
            clhLocation = new ColumnHeader();
            clhAmountOfRooms = new ColumnHeader();
            panel1 = new Panel();
            btnRemoveHotel = new Button();
            btnEditHotel = new Button();
            btnCreateHotel = new Button();
            lblSearch = new Label();
            txbSearch = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lvHotelDisplay
            // 
            lvHotelDisplay.Columns.AddRange(new ColumnHeader[] { clhId, clhName, clhRating, clhLocation, clhAmountOfRooms });
            lvHotelDisplay.Dock = DockStyle.Left;
            lvHotelDisplay.Font = new Font("Segoe UI", 11F);
            lvHotelDisplay.FullRowSelect = true;
            lvHotelDisplay.Location = new Point(0, 0);
            lvHotelDisplay.Name = "lvHotelDisplay";
            lvHotelDisplay.Size = new Size(890, 465);
            lvHotelDisplay.TabIndex = 0;
            lvHotelDisplay.UseCompatibleStateImageBehavior = false;
            lvHotelDisplay.View = View.Details;
            lvHotelDisplay.ItemSelectionChanged += lvHotelDisplay_ItemSelectionChanged;
            lvHotelDisplay.SelectedIndexChanged += lvHotelDisplay_SelectedIndexChanged;
            // 
            // clhId
            // 
            clhId.Text = "Id";
            clhId.Width = 50;
            // 
            // clhName
            // 
            clhName.Text = "Name";
            clhName.Width = 160;
            // 
            // clhRating
            // 
            clhRating.Text = "Rating";
            clhRating.Width = 80;
            // 
            // clhLocation
            // 
            clhLocation.Text = "Location";
            clhLocation.Width = 160;
            // 
            // clhAmountOfRooms
            // 
            clhAmountOfRooms.Text = "Amount of Room types";
            clhAmountOfRooms.Width = 240;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnRemoveHotel);
            panel1.Controls.Add(btnEditHotel);
            panel1.Controls.Add(btnCreateHotel);
            panel1.Controls.Add(lvHotelDisplay);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 233);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 465);
            panel1.TabIndex = 1;
            // 
            // btnRemoveHotel
            // 
            btnRemoveHotel.Location = new Point(897, 187);
            btnRemoveHotel.Name = "btnRemoveHotel";
            btnRemoveHotel.Size = new Size(167, 85);
            btnRemoveHotel.TabIndex = 4;
            btnRemoveHotel.Text = "Remove hotel";
            btnRemoveHotel.UseVisualStyleBackColor = true;
            btnRemoveHotel.Click += btnRemoveHotel_Click;
            // 
            // btnEditHotel
            // 
            btnEditHotel.Location = new Point(897, 95);
            btnEditHotel.Name = "btnEditHotel";
            btnEditHotel.Size = new Size(167, 85);
            btnEditHotel.TabIndex = 3;
            btnEditHotel.Text = "Edit hotel";
            btnEditHotel.UseVisualStyleBackColor = true;
            btnEditHotel.Click += btnEditHotel_Click;
            // 
            // btnCreateHotel
            // 
            btnCreateHotel.Location = new Point(897, 3);
            btnCreateHotel.Name = "btnCreateHotel";
            btnCreateHotel.Size = new Size(167, 85);
            btnCreateHotel.TabIndex = 2;
            btnCreateHotel.Text = "Add hotel";
            btnCreateHotel.UseVisualStyleBackColor = true;
            btnCreateHotel.Click += btnCreateHotel_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(17, 85);
            lblSearch.Margin = new Padding(4, 0, 4, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(64, 25);
            lblSearch.TabIndex = 2;
            lblSearch.Text = "Search";
            // 
            // txbSearch
            // 
            txbSearch.Location = new Point(86, 80);
            txbSearch.Margin = new Padding(4, 5, 4, 5);
            txbSearch.Name = "txbSearch";
            txbSearch.Size = new Size(305, 31);
            txbSearch.TabIndex = 3;
            // 
            // HotelOverview
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 698);
            Controls.Add(txbSearch);
            Controls.Add(lblSearch);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "HotelOverview";
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "HOTEL OVERVIEW";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvHotelDisplay;
        private Panel panel1;
        private ColumnHeader clhName;
        private ColumnHeader clhLocation;
        private ColumnHeader clhId;
        private ColumnHeader clhRating;
        private ColumnHeader clhAmountOfRooms;
        private Button btnCreateHotel;
        private Button btnEditHotel;
        private Button btnRemoveHotel;
        private Label lblSearch;
        private TextBox txbSearch;
    }
}