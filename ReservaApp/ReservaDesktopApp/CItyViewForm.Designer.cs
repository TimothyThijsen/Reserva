namespace ReservaDesktopApp
{
	partial class CItyViewForm
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
			lvCities = new ListView();
			clmId = new ColumnHeader();
			clmName = new ColumnHeader();
			btnRemoveCity = new Button();
			grbAddCity = new GroupBox();
			btnClear = new Button();
			btnSave = new Button();
			txbName = new TextBox();
			lblName = new Label();
			btnAddCity = new Button();
			btnEdit = new Button();
			grbAddCity.SuspendLayout();
			SuspendLayout();
			// 
			// lvCities
			// 
			lvCities.Columns.AddRange(new ColumnHeader[] { clmId, clmName });
			lvCities.FullRowSelect = true;
			lvCities.Location = new Point(257, 186);
			lvCities.Name = "lvCities";
			lvCities.Size = new Size(232, 221);
			lvCities.TabIndex = 0;
			lvCities.UseCompatibleStateImageBehavior = false;
			lvCities.View = View.Details;
			lvCities.ItemSelectionChanged += lvCities_ItemSelectionChanged;
			lvCities.SelectedIndexChanged += lvCities_SelectedIndexChanged;
			// 
			// clmId
			// 
			clmId.Text = "id";
			// 
			// clmName
			// 
			clmName.Text = "Name";
			clmName.Width = 120;
			// 
			// btnRemoveCity
			// 
			btnRemoveCity.Location = new Point(507, 230);
			btnRemoveCity.Name = "btnRemoveCity";
			btnRemoveCity.Size = new Size(81, 38);
			btnRemoveCity.TabIndex = 1;
			btnRemoveCity.Text = "Remove";
			btnRemoveCity.UseVisualStyleBackColor = true;
			btnRemoveCity.Click += btnRemoveCity_Click;
			// 
			// grbAddCity
			// 
			grbAddCity.Controls.Add(btnClear);
			grbAddCity.Controls.Add(btnSave);
			grbAddCity.Controls.Add(txbName);
			grbAddCity.Controls.Add(lblName);
			grbAddCity.Controls.Add(btnAddCity);
			grbAddCity.Location = new Point(257, 12);
			grbAddCity.Name = "grbAddCity";
			grbAddCity.Size = new Size(232, 168);
			grbAddCity.TabIndex = 2;
			grbAddCity.TabStop = false;
			grbAddCity.Text = "Add location";
			// 
			// btnClear
			// 
			btnClear.Location = new Point(6, 124);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(81, 38);
			btnClear.TabIndex = 7;
			btnClear.Text = "Clear";
			btnClear.UseVisualStyleBackColor = true;
			btnClear.Click += btnClear_Click;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(130, 124);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(81, 38);
			btnSave.TabIndex = 6;
			btnSave.Text = "Save";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// txbName
			// 
			txbName.Location = new Point(72, 41);
			txbName.Name = "txbName";
			txbName.Size = new Size(139, 23);
			txbName.TabIndex = 5;
			// 
			// lblName
			// 
			lblName.AutoSize = true;
			lblName.Location = new Point(17, 44);
			lblName.Name = "lblName";
			lblName.Size = new Size(39, 15);
			lblName.TabIndex = 4;
			lblName.Text = "Name";
			// 
			// btnAddCity
			// 
			btnAddCity.Location = new Point(130, 124);
			btnAddCity.Name = "btnAddCity";
			btnAddCity.Size = new Size(81, 38);
			btnAddCity.TabIndex = 3;
			btnAddCity.Text = "Add";
			btnAddCity.UseVisualStyleBackColor = true;
			btnAddCity.Click += btnAddCity_Click;
			// 
			// btnEdit
			// 
			btnEdit.Location = new Point(507, 186);
			btnEdit.Name = "btnEdit";
			btnEdit.Size = new Size(81, 38);
			btnEdit.TabIndex = 3;
			btnEdit.Text = "Edit";
			btnEdit.UseVisualStyleBackColor = true;
			btnEdit.Click += btnEdit_Click;
			// 
			// CItyViewForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(756, 419);
			Controls.Add(btnEdit);
			Controls.Add(grbAddCity);
			Controls.Add(btnRemoveCity);
			Controls.Add(lvCities);
			FormBorderStyle = FormBorderStyle.None;
			Name = "CItyViewForm";
			Text = "Location";
			grbAddCity.ResumeLayout(false);
			grbAddCity.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private ListView lvCities;
		private ColumnHeader clmId;
		private ColumnHeader clmName;
		private Button btnRemoveCity;
		private GroupBox grbAddCity;
		private TextBox txbName;
		private Label lblName;
		private Button btnAddCity;
		private Button btnSave;
		private Button btnEdit;
		private Button btnClear;
	}
}