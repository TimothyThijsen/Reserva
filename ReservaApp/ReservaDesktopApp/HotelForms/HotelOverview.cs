﻿using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.Extensions.DependencyInjection;


namespace ReservaDesktopApp.HotelForms
{
    public partial class HotelOverview : Form
    {
        HotelManager hotelManager;
        CityManager cityManager;
        RoomManager roomManager;
        Hotel? selectedHotel;
        public HotelOverview()
        {
            InitializeComponent();
            hotelManager = Program.ServiceProvider.GetRequiredService<HotelManager>();
            cityManager = Program.ServiceProvider.GetRequiredService<CityManager>();
            roomManager = Program.ServiceProvider.GetRequiredService<RoomManager>();
            ShowHotels();
        }
        private void ShowHotels()
        {
            lvHotelDisplay.Items.Clear();
            try
            {
                foreach (Hotel hotel in hotelManager.GetAllHotels())
                {
                    ListViewItem item = new ListViewItem(hotel.Id.ToString());
                    item.Tag = hotel;
                    item.SubItems.Add(hotel.Name);
                    item.SubItems.Add("0");
                    item.SubItems.Add(cityManager.GetCity(hotel.CityId).Name);
                    item.SubItems.Add(roomManager.GetRoomByHotel(hotel.Id).Count().ToString());

                    lvHotelDisplay.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        void Form_Closing(object sender, EventArgs e)
        {
            ShowHotels();
        }


        private void btnCreateHotel_Click(object sender, EventArgs e)
        {
            CreateHotelForm childForm = new CreateHotelForm();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ((System.Windows.Forms.Panel)Application.OpenForms["MainForm"]!.Controls["panelDesktopPanel"]!).Controls.Add(childForm);
            childForm.BringToFront();
            childForm.FormClosing += Form_Closing!;
            childForm.Show();

        }

        private void btnEditHotel_Click(object sender, EventArgs e)
        {
            if (selectedHotel == null)
            {
                MessageBox.Show("Select a hotel");
                return;
            }
            EditHotelForm childForm = new EditHotelForm(selectedHotel);

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ((System.Windows.Forms.Panel)Application.OpenForms["MainForm"]!.Controls["panelDesktopPanel"]!).Controls.Add(childForm);
            childForm.BringToFront();
            childForm.FormClosing += Form_Closing!;
            childForm.Show();
        }

        private void btnRemoveHotel_Click(object sender, EventArgs e)
        {
            if (selectedHotel == null)
            {
                MessageBox.Show("Select a hotel");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    hotelManager.RemoveHotel(selectedHotel.Id);
                    ShowHotels();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void lvHotelDisplay_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedHotel = e.Item!.Tag as Hotel;
        }

        private void lvHotelDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHotelDisplay.SelectedItems.Count == 0)
            {
                selectedHotel = null;
            }
        }

        private void btnRoomManagement_Click(object sender, EventArgs e)
        {
            if (selectedHotel == null)
            {
                MessageBox.Show("Select a hotel");
                return;
            }
            RoomManagementForm childForm = new RoomManagementForm(selectedHotel);

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ((System.Windows.Forms.Panel)Application.OpenForms["MainForm"]!.Controls["panelDesktopPanel"]!).Controls.Add(childForm);
            childForm.BringToFront();
            childForm.FormClosing += Form_Closing!;
            childForm.Show();
        }
    }
}
