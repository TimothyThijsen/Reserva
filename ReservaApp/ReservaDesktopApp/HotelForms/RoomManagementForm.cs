using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservaDesktopApp.HotelForms
{
	public partial class RoomManagementForm : Form
	{
		Hotel hotel;
		RoomManager roomManager;
		Room? selectedRoom;
		int roomEditId;
		public RoomManagementForm(Hotel selectedHotel)
		{
			InitializeComponent();
			hotel = selectedHotel;
			roomManager = Program.ServiceProvider.GetRequiredService<RoomManager>();
			SetupRoomDisplay();
		}
		private void SetupRoomDisplay()
		{
			lvRoomDisplay.Items.Clear();
			try
			{
				foreach (Room room in roomManager.GetRoomByHotel(hotel.Id))
				{
					ListViewItem item = new ListViewItem(room.Name);
					item.Tag = room;
					item.SubItems.Add(room.Quantity.ToString());
					item.SubItems.Add(room.Price.ToString("0.00"));
					item.SubItems.Add(room.Capacity.ToString());
					item.SubItems.Add(room.BedType);

					lvRoomDisplay.Items.Add(item);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			btnSaveEdit.Visible = false;
		}
		private void btnAddRoom_Click(object sender, EventArgs e)
		{
			string name;
			int quantity;
			int capacity;
			decimal price;
			string bedType;
			bool success = false;
			try
			{
				if (txbName.Text == string.Empty) { throw new Exception("Please provide a name"); }
				name = txbName.Text;
				if (nmrCapacity.Value < 1) { throw new Exception("Please provide a valid capacity"); }
				capacity = Convert.ToInt32(nmrCapacity.Value);
				if (nmrQuantity.Value < 1) { throw new Exception("Please provide a valid Quantity"); }
				quantity = Convert.ToInt32(nmrQuantity.Value);
				if (nmrPrice.Value < 1) { throw new Exception("Please provide a valid Price"); }
				price = nmrPrice.Value;
				if (txbBedType.Text == string.Empty) { throw new Exception("Please provide a bedtype"); }
				bedType = txbBedType.Text;
				roomManager.AddRoom(new Room(hotel.Id, name, quantity, price, capacity, bedType));
				success = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			if (success)
			{
				SetupRoomDisplay();
			}
		}
		private void lvRoomDisplay_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			selectedRoom = e.Item!.Tag as Room;
		}

		private void lvRoomDisplay_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvRoomDisplay.SelectedItems.Count == 0)
			{
				selectedRoom = null;
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{

			if (selectedRoom == null)
			{
				MessageBox.Show("Select a room");
				return;
			}
			roomEditId = selectedRoom.Id;
			txbName.Text = selectedRoom.Name;
			nmrCapacity.Value = selectedRoom.Capacity;
			nmrQuantity.Value = selectedRoom.Quantity;
			nmrPrice.Value = selectedRoom.Price;
			txbBedType.Text = selectedRoom.BedType;
			btnSaveEdit.Visible = true;
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txbName.Clear();
			nmrCapacity.Value = 1;
			nmrQuantity.Value = 1;
			nmrPrice.Value = 0;
			txbBedType.Clear();
			btnSaveEdit.Visible = false;
		}

		private void btnSaveEdit_Click(object sender, EventArgs e)
		{
			string name;
			int quantity;
			int capacity;
			decimal price;
			string bedType;
			bool success = false;
			try
			{
				if (txbName.Text == string.Empty) { throw new Exception("Please provide a name"); }
				name = txbName.Text;
				if (nmrCapacity.Value < 1) { throw new Exception("Please provide a valid capacity"); }
				capacity = Convert.ToInt32(nmrCapacity.Value);
				if (nmrQuantity.Value < 1) { throw new Exception("Please provide a valid Quantity"); }
				quantity = Convert.ToInt32(nmrQuantity.Value);
				if (nmrPrice.Value < 1) { throw new Exception("Please provide a valid Price"); }
				price = nmrPrice.Value;
				if (txbBedType.Text == string.Empty) { throw new Exception("Please provide a bedtype"); }
				bedType = txbBedType.Text;
				roomManager.EditRoom(new Room(roomEditId, hotel.Id, name, quantity, price, capacity, bedType));
				success = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			if (success)
			{
				btnClear.PerformClick();
				SetupRoomDisplay();

			}

		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnRemoveRoom_Click(object sender, EventArgs e)
		{
			if (selectedRoom == null)
			{
				MessageBox.Show("Select a room");
				return;
			}
			try
			{
				roomManager.RemoveRoom(selectedRoom.Id);
				SetupRoomDisplay();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}
	}
}
