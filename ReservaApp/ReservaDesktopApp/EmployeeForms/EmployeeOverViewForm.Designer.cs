namespace ReservaDesktopApp.EmployeeForms
{
    partial class EmployeeOverViewForm
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
            btnRemoveEmployee = new Button();
            btnEditEmployee = new Button();
            btnCreateEmployee = new Button();
            lvEmployeeDisplay = new ListView();
            clhId = new ColumnHeader();
            clhFName = new ColumnHeader();
            clhEmail = new ColumnHeader();
            clhRole = new ColumnHeader();
            clhPhoneNumber = new ColumnHeader();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnRemoveEmployee);
            panel1.Controls.Add(btnEditEmployee);
            panel1.Controls.Add(btnCreateEmployee);
            panel1.Controls.Add(lvEmployeeDisplay);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 233);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 465);
            panel1.TabIndex = 2;
            // 
            // btnRemoveEmployee
            // 
            btnRemoveEmployee.Location = new Point(900, 188);
            btnRemoveEmployee.Name = "btnRemoveEmployee";
            btnRemoveEmployee.Size = new Size(167, 85);
            btnRemoveEmployee.TabIndex = 4;
            btnRemoveEmployee.Text = "Remove employee";
            btnRemoveEmployee.UseVisualStyleBackColor = true;
            btnRemoveEmployee.Click += btnRemoveEmployee_Click;
            // 
            // btnEditEmployee
            // 
            btnEditEmployee.Location = new Point(901, 97);
            btnEditEmployee.Name = "btnEditEmployee";
            btnEditEmployee.Size = new Size(167, 85);
            btnEditEmployee.TabIndex = 3;
            btnEditEmployee.Text = "Edit employee";
            btnEditEmployee.UseVisualStyleBackColor = true;
            btnEditEmployee.Click += btnEditEmployee_Click;
            // 
            // btnCreateEmployee
            // 
            btnCreateEmployee.Location = new Point(901, 5);
            btnCreateEmployee.Name = "btnCreateEmployee";
            btnCreateEmployee.Size = new Size(167, 85);
            btnCreateEmployee.TabIndex = 2;
            btnCreateEmployee.Text = "Add employee";
            btnCreateEmployee.UseVisualStyleBackColor = true;
            btnCreateEmployee.Click += btnCreateEmployee_Click;
            // 
            // lvEmployeeDisplay
            // 
            lvEmployeeDisplay.Columns.AddRange(new ColumnHeader[] { clhId, clhFName, clhEmail, clhRole, clhPhoneNumber });
            lvEmployeeDisplay.Dock = DockStyle.Left;
            lvEmployeeDisplay.Font = new Font("Segoe UI", 11F);
            lvEmployeeDisplay.FullRowSelect = true;
            lvEmployeeDisplay.Location = new Point(0, 0);
            lvEmployeeDisplay.Name = "lvEmployeeDisplay";
            lvEmployeeDisplay.Size = new Size(894, 465);
            lvEmployeeDisplay.TabIndex = 0;
            lvEmployeeDisplay.UseCompatibleStateImageBehavior = false;
            lvEmployeeDisplay.View = View.Details;
            lvEmployeeDisplay.ItemSelectionChanged += lvEmployeeDisplay_ItemSelectionChanged;
            lvEmployeeDisplay.SelectedIndexChanged += lvEmployeeDisplay_SelectedIndexChanged;
            // 
            // clhId
            // 
            clhId.Text = "Id";
            clhId.Width = 50;
            // 
            // clhFName
            // 
            clhFName.Text = "Name";
            clhFName.Width = 160;
            // 
            // clhEmail
            // 
            clhEmail.Text = "Email";
            clhEmail.Width = 80;
            // 
            // clhRole
            // 
            clhRole.Text = "Role";
            clhRole.Width = 160;
            // 
            // clhPhoneNumber
            // 
            clhPhoneNumber.Text = "Phone number";
            clhPhoneNumber.Width = 180;
            // 
            // EmployeeOverViewForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 698);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EmployeeOverViewForm";
            Text = "Employees";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnRemoveEmployee;
        private Button btnEditEmployee;
        private Button btnCreateEmployee;
        private ListView lvEmployeeDisplay;
        private ColumnHeader clhId;
        private ColumnHeader clhFName;
        private ColumnHeader clhEmail;
        private ColumnHeader clhRole;
        private ColumnHeader clhPhoneNumber;
    }
}