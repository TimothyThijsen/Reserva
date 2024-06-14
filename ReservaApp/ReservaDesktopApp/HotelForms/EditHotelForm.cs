using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.Extensions.DependencyInjection;
using Models;

namespace ReservaDesktopApp.HotelForms
{
    public partial class EditHotelForm : Form
    {
        Hotel hotel;
        CityManager cityManager;
        HotelManager hotelManager;
        public EditHotelForm(Hotel hotel)
        {
            InitializeComponent();
            cityManager = Program.ServiceProvider.GetRequiredService<CityManager>();
            hotelManager = Program.ServiceProvider.GetRequiredService<HotelManager>();
            this.hotel = hotel;
            SetupForm();
        }
        public void SetupForm()
        {
            txbName.Text = hotel.Name;
            txbStreet.Text = hotel.Address.Street;
            txbDescription.Text = hotel.Description;
            txbPostalCode.Text = hotel.Description;

            List<City> citiesComboItems = new List<City>();
            cmbCities.Items.Clear();
            foreach (City city in cityManager.GetAllCities())
            {
                citiesComboItems.Add(city);

            }

            cmbCities.DisplayMember = "Name";
            cmbCities.ValueMember = "Id";
            cmbCities.DataSource = citiesComboItems;
            cmbCities.SelectedIndex = citiesComboItems.FindIndex(c => c.Id == hotel.CityId);

            cmbPricingAlgorithm.Items.Add(new ComboBoxItem("No Discount", "NoDiscount"));
            cmbPricingAlgorithm.Items.Add(new ComboBoxItem("Reserva Curve", "ReservaCurve"));
            cmbPricingAlgorithm.Items.Add(new ComboBoxItem("Reserva Curve + Seasonal Northern", "ReservaCurve, SeasonalNorthern"));
            cmbPricingAlgorithm.Items.Add(new ComboBoxItem("Reserva Curve + Seasonal Southern", "ReservaCurve, SeasonalSouthern"));
            cmbPricingAlgorithm.Items.Add(new ComboBoxItem("Seasonal Northern", "SeasonalNorthern"));
            cmbPricingAlgorithm.Items.Add(new ComboBoxItem("Seasonal Southern", "SeasonalSouthern"));
            cmbPricingAlgorithm.Items.Add(new ComboBoxItem("Minimal Curve", "MinimalCurve"));
            cmbPricingAlgorithm.Items.Add(new ComboBoxItem("Minimal Curve + Seasonal Northern", "MinimalCurve, SeasonalNorthern"));
            cmbPricingAlgorithm.Items.Add(new ComboBoxItem("Minimal Curve + Seasonal Southern", "MinimalCurve, SeasonalSouthern"));


            foreach (ComboBoxItem item in cmbPricingAlgorithm.Items)
            {
                if (item.HiddenValue == hotel.PricingAlgorithms)
                {
                    cmbPricingAlgorithm.SelectedItem = item;
                    break;
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string name;
            string description;
            City city;
            string postalCode;
            string street;
            bool success = false;
            string pricingAlgorithms;
            try
            {
                if (txbName.Text == string.Empty) { throw new Exception("Please provide a name"); }
                name = txbName.Text;
                if (txbDescription.Text == string.Empty) throw new Exception("Please provide a description");
                description = txbDescription.Text;
                if (cmbCities.SelectedIndex < 0) { throw new Exception("Please select a city"); }
                city = (City)cmbCities.SelectedItem;
                if (txbPostalCode.Text == string.Empty) { throw new Exception("Please provide a postal code"); }
                postalCode = txbPostalCode.Text;
                if (txbStreet.Text == string.Empty) { throw new Exception("Please provide a street address"); }
                street = txbStreet.Text;
                pricingAlgorithms = ((ComboBoxItem)cmbPricingAlgorithm.SelectedItem).HiddenValue;
                hotelManager.EditHotel(new Hotel(hotel.Id, name, description, city.Id, new Address(street, postalCode), pricingAlgorithms));
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (success)
            {
                this.Close();
            }
        }
    }
}
