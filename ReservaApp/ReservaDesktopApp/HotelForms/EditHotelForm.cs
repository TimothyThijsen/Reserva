using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
				if (txbPostalCode.Text == string.Empty) { throw new Exception("Please provide a postal code"); }
				postalCode = txbPostalCode.Text;
				if (txbStreet.Text == string.Empty) { throw new Exception("Please provide a street address"); }
				street = txbStreet.Text;
				hotelManager.EditHotel(new Hotel(hotel.Id,name, description, city.Id, new Address(street, postalCode)));
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
