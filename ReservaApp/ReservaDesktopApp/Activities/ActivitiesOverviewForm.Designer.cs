namespace ReservaDesktopApp
{
    partial class ActivitiesOverviewForm
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
            btnRemoveActivity = new Button();
            btnEditActivity = new Button();
            btnAddActivity = new Button();
            lvActivityDisplay = new ListView();
            clhId = new ColumnHeader();
            clhName = new ColumnHeader();
            clhPrice = new ColumnHeader();
            clhCapacity = new ColumnHeader();
            clhLocation = new ColumnHeader();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnRemoveActivity);
            panel1.Controls.Add(btnEditActivity);
            panel1.Controls.Add(btnAddActivity);
            panel1.Controls.Add(lvActivityDisplay);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 233);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 465);
            panel1.TabIndex = 2;
            // 
            // btnRemoveActivity
            // 
            btnRemoveActivity.Location = new Point(900, 188);
            btnRemoveActivity.Name = "btnRemoveActivity";
            btnRemoveActivity.Size = new Size(167, 85);
            btnRemoveActivity.TabIndex = 4;
            btnRemoveActivity.Text = "Remove activity";
            btnRemoveActivity.UseVisualStyleBackColor = true;
            btnRemoveActivity.Click += btnRemoveActivity_Click;
            // 
            // btnEditActivity
            // 
            btnEditActivity.Location = new Point(901, 97);
            btnEditActivity.Name = "btnEditActivity";
            btnEditActivity.Size = new Size(167, 85);
            btnEditActivity.TabIndex = 3;
            btnEditActivity.Text = "Edit activity";
            btnEditActivity.UseVisualStyleBackColor = true;
            btnEditActivity.Click += btnEditActivity_Click;
            // 
            // btnAddActivity
            // 
            btnAddActivity.Location = new Point(901, 5);
            btnAddActivity.Name = "btnAddActivity";
            btnAddActivity.Size = new Size(167, 85);
            btnAddActivity.TabIndex = 2;
            btnAddActivity.Text = "Add activity";
            btnAddActivity.UseVisualStyleBackColor = true;
            btnAddActivity.Click += btnCreateActivity_Click;
            // 
            // lvActivityDisplay
            // 
            lvActivityDisplay.Columns.AddRange(new ColumnHeader[] { clhId, clhName, clhPrice, clhCapacity, clhLocation });
            lvActivityDisplay.Dock = DockStyle.Left;
            lvActivityDisplay.Font = new Font("Segoe UI", 11F);
            lvActivityDisplay.FullRowSelect = true;
            lvActivityDisplay.Location = new Point(0, 0);
            lvActivityDisplay.Name = "lvActivityDisplay";
            lvActivityDisplay.Size = new Size(894, 465);
            lvActivityDisplay.TabIndex = 0;
            lvActivityDisplay.UseCompatibleStateImageBehavior = false;
            lvActivityDisplay.View = View.Details;
            lvActivityDisplay.ItemSelectionChanged += lvActivityDisplay_ItemSelectionChanged;
            lvActivityDisplay.SelectedIndexChanged += lvActivityDisplay_SelectedIndexChanged;
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
            // clhPrice
            // 
            clhPrice.Text = "Price";
            clhPrice.Width = 80;
            // 
            // clhCapacity
            // 
            clhCapacity.DisplayIndex = 4;
            clhCapacity.Text = "Capacity";
            clhCapacity.Width = 180;
            // 
            // clhLocation
            // 
            clhLocation.DisplayIndex = 3;
            clhLocation.Text = "Location";
            clhLocation.Width = 160;
            // 
            // ActivitiesOverviewForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 698);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ActivitiesOverviewForm";
            Text = "Activities";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnRemoveActivity;
        private Button btnEditActivity;
        private Button btnAddActivity;
        private ListView lvActivityDisplay;
        private ColumnHeader clhId;
        private ColumnHeader clhName;
        private ColumnHeader clhPrice;
        private ColumnHeader clhLocation;
        private ColumnHeader clhCapacity;
    }
}