using DomainLayer.ServiceClasses;
using DomainLayer;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace ReservaDesktopApp.Activities
{
    public partial class CreateActivitiesForm : Form
    {
        CityManager cityManager;
        ActivitiesManager activitiesManager;
        public CreateActivitiesForm()
        {
            InitializeComponent();
            activitiesManager = Program.ServiceProvider.GetRequiredService<ActivitiesManager>();
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
            int capacity;
            decimal price;
            bool success = false;
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
                if (nmrCapacity.Value <1) { throw new Exception("Please provide a capacity bigger than 0"); }
                capacity = Convert.ToInt32(nmrCapacity.Value);
                price = nmrPrice.Value;
                activitiesManager.AddActivity(new Activity(city.Id, capacity, name, description, price, new Address(street, postalCode)));
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
