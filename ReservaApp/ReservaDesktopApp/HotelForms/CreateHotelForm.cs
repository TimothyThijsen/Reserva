using DataAccessLayer;
using DomainLayer.ServiceClasses;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Extensions.DependencyInjection;

namespace ReservaDesktopApp.HotelForms
{
    public partial class CreateHotelForm : Form
    {
        CityManager cityManager;
        HotelManager hotelManager;
       

        public CreateHotelForm()
        {
            InitializeComponent();
            hotelManager = Program.ServiceProvider.GetRequiredService<HotelManager>();
            cityManager = Program.ServiceProvider.GetRequiredService<CityManager>();
            Setup();
        }
        public void Setup()
        {
            List<City> citiesComboItems = new List<City>();
            cmbCities.Items.Clear();
            

            foreach (City city in cityManager.GetAllCities())
            {
                citiesComboItems.Add(city);

            }

            cmbCities.DisplayMember = "Name";
            cmbCities.ValueMember = "Id";    
            cmbCities.DataSource = citiesComboItems;
            cmbCities.SelectedIndex = -1;
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
            try
            {
                if (txbName.Text == string.Empty) { throw new Exception("Please provide a name"); }
                name = txbName.Text;
                if (txbDescription.Text == string.Empty) throw new Exception("Please provide a description");
                description = txbDescription.Text;
                if (cmbCities.SelectedIndex < 0) { throw new Exception("Please select a city"); }
                city = (City)cmbCities.SelectedItem;
                if(txbPostalCode.Text == string.Empty) { throw new Exception("Please provide a postal code"); }
                postalCode = txbPostalCode.Text;
                if(txbStreet.Text == string.Empty) { throw new Exception("Please provide a street address"); }
                street = txbStreet.Text;
                hotelManager.AddHotel(new Hotel(name, description, city.Id, new Address(street, postalCode)));
                success = true;
            }
            catch(Exception ex)
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
