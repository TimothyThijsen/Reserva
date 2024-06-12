namespace ReservaDesktopApp.HotelForms
{
	partial class RoomManagementForm
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
			lvRoomDisplay = new ListView();
			name = new ColumnHeader();
			quantity = new ColumnHeader();
			price = new ColumnHeader();
			chCapacity = new ColumnHeader();
			BedType = new ColumnHeader();
			txbName = new TextBox();
			txbBedType = new TextBox();
			nmrCapacity = new NumericUpDown();
			nmrPrice = new NumericUpDown();
			nmrQuantity = new NumericUpDown();
			groupBox1 = new GroupBox();
			btnSaveEdit = new Button();
			btnClear = new Button();
			btnAddRoom = new Button();
			lblBedType = new Label();
			lblPrice = new Label();
			lblCapacity = new Label();
			lblQuantity = new Label();
			lblName = new Label();
			btnEdit = new Button();
			btnRemoveRoom = new Button();
			btnClose = new Button();
			((System.ComponentModel.ISupportInitialize)nmrCapacity).BeginInit();
			((System.ComponentModel.ISupportInitialize)nmrPrice).BeginInit();
			((System.ComponentModel.ISupportInitialize)nmrQuantity).BeginInit();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// lvRoomDisplay
			// 
			lvRoomDisplay.Columns.AddRange(new ColumnHeader[] { name, quantity, price, chCapacity, BedType });
			lvRoomDisplay.FullRowSelect = true;
			lvRoomDisplay.Location = new Point(123, 338);
			lvRoomDisplay.Margin = new Padding(4, 5, 4, 5);
			lvRoomDisplay.Name = "lvRoomDisplay";
			lvRoomDisplay.Size = new Size(613, 379);
			lvRoomDisplay.TabIndex = 0;
			lvRoomDisplay.UseCompatibleStateImageBehavior = false;
			lvRoomDisplay.View = View.Details;
			lvRoomDisplay.ItemSelectionChanged += lvRoomDisplay_ItemSelectionChanged;
			lvRoomDisplay.SelectedIndexChanged += lvRoomDisplay_SelectedIndexChanged;
			// 
			// name
			// 
			name.Text = "Name";
			name.Width = 120;
			// 
			// quantity
			// 
			quantity.Text = "Quantity";
			// 
			// price
			// 
			price.Text = "Price";
			// 
			// chCapacity
			// 
			chCapacity.Text = "Capacity";
			// 
			// BedType
			// 
			BedType.Text = "clmBedType";
			BedType.Width = 100;
			// 
			// txbName
			// 
			txbName.Location = new Point(159, 37);
			txbName.Margin = new Padding(4, 5, 4, 5);
			txbName.Name = "txbName";
			txbName.Size = new Size(170, 31);
			txbName.TabIndex = 1;
			// 
			// txbBedType
			// 
			txbBedType.Location = new Point(159, 237);
			txbBedType.Margin = new Padding(4, 5, 4, 5);
			txbBedType.Name = "txbBedType";
			txbBedType.Size = new Size(270, 31);
			txbBedType.TabIndex = 3;
			// 
			// nmrCapacity
			// 
			nmrCapacity.Location = new Point(159, 133);
			nmrCapacity.Margin = new Padding(4, 5, 4, 5);
			nmrCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			nmrCapacity.Name = "nmrCapacity";
			nmrCapacity.Size = new Size(171, 31);
			nmrCapacity.TabIndex = 4;
			nmrCapacity.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// nmrPrice
			// 
			nmrPrice.BackColor = Color.White;
			nmrPrice.DecimalPlaces = 2;
			nmrPrice.Location = new Point(159, 182);
			nmrPrice.Margin = new Padding(4, 5, 4, 5);
			nmrPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
			nmrPrice.Name = "nmrPrice";
			nmrPrice.Size = new Size(171, 31);
			nmrPrice.TabIndex = 5;
			nmrPrice.Tag = "";
			// 
			// nmrQuantity
			// 
			nmrQuantity.Location = new Point(159, 85);
			nmrQuantity.Margin = new Padding(4, 5, 4, 5);
			nmrQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
			nmrQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			nmrQuantity.Name = "nmrQuantity";
			nmrQuantity.Size = new Size(171, 31);
			nmrQuantity.TabIndex = 6;
			nmrQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(btnSaveEdit);
			groupBox1.Controls.Add(btnClear);
			groupBox1.Controls.Add(btnAddRoom);
			groupBox1.Controls.Add(lblBedType);
			groupBox1.Controls.Add(lblPrice);
			groupBox1.Controls.Add(lblCapacity);
			groupBox1.Controls.Add(lblQuantity);
			groupBox1.Controls.Add(lblName);
			groupBox1.Controls.Add(txbName);
			groupBox1.Controls.Add(nmrQuantity);
			groupBox1.Controls.Add(txbBedType);
			groupBox1.Controls.Add(nmrPrice);
			groupBox1.Controls.Add(nmrCapacity);
			groupBox1.Location = new Point(166, 5);
			groupBox1.Margin = new Padding(4, 5, 4, 5);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(4, 5, 4, 5);
			groupBox1.Size = new Size(487, 333);
			groupBox1.TabIndex = 7;
			groupBox1.TabStop = false;
			groupBox1.Text = "Add Room";
			// 
			// btnSaveEdit
			// 
			btnSaveEdit.Location = new Point(321, 285);
			btnSaveEdit.Margin = new Padding(4, 5, 4, 5);
			btnSaveEdit.Name = "btnSaveEdit";
			btnSaveEdit.Size = new Size(107, 38);
			btnSaveEdit.TabIndex = 14;
			btnSaveEdit.Text = "Save";
			btnSaveEdit.UseVisualStyleBackColor = true;
			btnSaveEdit.Click += btnSaveEdit_Click;
			// 
			// btnClear
			// 
			btnClear.Location = new Point(21, 285);
			btnClear.Margin = new Padding(4, 5, 4, 5);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(107, 38);
			btnClear.TabIndex = 13;
			btnClear.Text = "Clear";
			btnClear.UseVisualStyleBackColor = true;
			btnClear.Click += btnClear_Click;
			// 
			// btnAddRoom
			// 
			btnAddRoom.Location = new Point(321, 285);
			btnAddRoom.Margin = new Padding(4, 5, 4, 5);
			btnAddRoom.Name = "btnAddRoom";
			btnAddRoom.Size = new Size(107, 38);
			btnAddRoom.TabIndex = 12;
			btnAddRoom.Text = "Add";
			btnAddRoom.UseVisualStyleBackColor = true;
			btnAddRoom.Click += btnAddRoom_Click;
			// 
			// lblBedType
			// 
			lblBedType.AutoSize = true;
			lblBedType.Location = new Point(21, 242);
			lblBedType.Margin = new Padding(4, 0, 4, 0);
			lblBedType.Name = "lblBedType";
			lblBedType.Size = new Size(82, 25);
			lblBedType.TabIndex = 11;
			lblBedType.Text = "Bed type";
			// 
			// lblPrice
			// 
			lblPrice.AutoSize = true;
			lblPrice.Location = new Point(21, 185);
			lblPrice.Margin = new Padding(4, 0, 4, 0);
			lblPrice.Name = "lblPrice";
			lblPrice.Size = new Size(126, 25);
			lblPrice.TabIndex = 10;
			lblPrice.Text = "Price per night";
			// 
			// lblCapacity
			// 
			lblCapacity.AutoSize = true;
			lblCapacity.Location = new Point(21, 137);
			lblCapacity.Margin = new Padding(4, 0, 4, 0);
			lblCapacity.Name = "lblCapacity";
			lblCapacity.Size = new Size(79, 25);
			lblCapacity.TabIndex = 9;
			lblCapacity.Text = "Capacity";
			// 
			// lblQuantity
			// 
			lblQuantity.AutoSize = true;
			lblQuantity.Location = new Point(21, 88);
			lblQuantity.Margin = new Padding(4, 0, 4, 0);
			lblQuantity.Name = "lblQuantity";
			lblQuantity.Size = new Size(80, 25);
			lblQuantity.TabIndex = 8;
			lblQuantity.Text = "Quantity";
			// 
			// lblName
			// 
			lblName.AutoSize = true;
			lblName.Location = new Point(21, 42);
			lblName.Margin = new Padding(4, 0, 4, 0);
			lblName.Name = "lblName";
			lblName.Size = new Size(59, 25);
			lblName.TabIndex = 7;
			lblName.Text = "Name";
			// 
			// btnEdit
			// 
			btnEdit.Location = new Point(746, 338);
			btnEdit.Margin = new Padding(4, 5, 4, 5);
			btnEdit.Name = "btnEdit";
			btnEdit.Size = new Size(136, 83);
			btnEdit.TabIndex = 9;
			btnEdit.Text = "Edit";
			btnEdit.UseVisualStyleBackColor = true;
			btnEdit.Click += btnEdit_Click;
			// 
			// btnRemoveRoom
			// 
			btnRemoveRoom.Location = new Point(746, 432);
			btnRemoveRoom.Margin = new Padding(4, 5, 4, 5);
			btnRemoveRoom.Name = "btnRemoveRoom";
			btnRemoveRoom.Size = new Size(136, 83);
			btnRemoveRoom.TabIndex = 10;
			btnRemoveRoom.Text = "Remove";
			btnRemoveRoom.UseVisualStyleBackColor = true;
			btnRemoveRoom.Click += btnRemoveRoom_Click;
			// 
			// btnClose
			// 
			btnClose.Location = new Point(787, 633);
			btnClose.Margin = new Padding(4, 5, 4, 5);
			btnClose.Name = "btnClose";
			btnClose.Size = new Size(179, 83);
			btnClose.TabIndex = 11;
			btnClose.Text = "Close";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += btnClose_Click;
			// 
			// RoomManagementForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1143, 750);
			Controls.Add(btnClose);
			Controls.Add(btnRemoveRoom);
			Controls.Add(btnEdit);
			Controls.Add(groupBox1);
			Controls.Add(lvRoomDisplay);
			FormBorderStyle = FormBorderStyle.None;
			Margin = new Padding(4, 5, 4, 5);
			Name = "RoomManagementForm";
			Text = "RoomManagmentForm";
			((System.ComponentModel.ISupportInitialize)nmrCapacity).EndInit();
			((System.ComponentModel.ISupportInitialize)nmrPrice).EndInit();
			((System.ComponentModel.ISupportInitialize)nmrQuantity).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private ListView lvRoomDisplay;
		private ColumnHeader name;
		private ColumnHeader quantity;
		private ColumnHeader price;
		private ColumnHeader chCapacity;
		private TextBox txbName;
		private TextBox txbBedType;
		private NumericUpDown nmrCapacity;
		private NumericUpDown nmrPrice;
		private NumericUpDown nmrQuantity;
		private GroupBox groupBox1;
		private Label lblBedType;
		private Label lblPrice;
		private Label lblCapacity;
		private Label lblQuantity;
		private Label lblName;
		private Button btnAddRoom;
		private ColumnHeader BedType;
		private Button btnEdit;
		private Button btnClear;
		private Button btnSaveEdit;
		private Button btnRemoveRoom;
		private Button btnClose;
	}
}