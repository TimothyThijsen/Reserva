using DataAccessLayer;
using DomainLayer;
using DomainLayer.ServiceClasses;


namespace ReservaDesktopApp.HotelForms
{
    public partial class HotelOverview : Form
    {
        HotelManager hotelManager = new HotelManager(new HotelDAL());
        CityManager cityManager = new CityManager(new CityDAL());
        RoomManager roomManager = new RoomManager(new RoomDAL());
        Hotel selectedHotel;
        public HotelOverview()
        {
            InitializeComponent();
            ShowHotels();
        }
        private void ShowHotels()
        {
            lvHotelDisplay.Items.Clear();
            try{
                foreach (Hotel hotel in hotelManager.GertAllHotels())
                {
                    ListViewItem item = new ListViewItem(hotel.Id.ToString());
                    item.Tag = hotel;
                    item.SubItems.Add(hotel.Name);
                    item.SubItems.Add("0");
                    item.SubItems.Add(cityManager.GetCity(hotel.CityId).Name);
                    item.SubItems.Add(roomManager.GetRoomByHotel(hotel.Id).Count().ToString());

                    lvHotelDisplay.Items.Add(item);
                }
            }catch(Exception ex)
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
            ((System.Windows.Forms.Panel)Application.OpenForms["MainForm"].Controls["panelDesktopPanel"]).Controls.Add(childForm);
            childForm.BringToFront();
            childForm.FormClosing += Form_Closing;
            childForm.Show();

        }

        private void btnEditHotel_Click(object sender, EventArgs e)
        {
            EditHotelForm childForm = new EditHotelForm();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ((System.Windows.Forms.Panel)Application.OpenForms["MainForm"].Controls["panelDesktopPanel"]).Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnRemoveHotel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented");
        }

        private void lvHotelDisplay_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedHotel = e.Item.Tag as Hotel;
        }

        private void lvHotelDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHotelDisplay.SelectedItems.Count == 0)
            {
                selectedHotel = null;
            }
        }
    }
}
