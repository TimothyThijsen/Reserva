using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.Extensions.DependencyInjection;
using Models;



namespace ReservaDesktopApp.Activities
{

    public partial class EditActivityForm : Form
    {
        Activity activity;
        CityManager cityManager;
        ActivitiesManager activitiesManager;
        public EditActivityForm(Activity activity)
        {
            InitializeComponent();
            cityManager = Program.ServiceProvider.GetRequiredService<CityManager>();
            activitiesManager = Program.ServiceProvider.GetRequiredService<ActivitiesManager>();
            this.activity = activity;
            SetupForm();
        }
        public void SetupForm()
        {
            txbName.Text = activity.Name;
            txbStreet.Text = activity.Address.Street;
            txbDescription.Text = activity.Description;
            txbPostalCode.Text = activity.Description;
            nmrCapacity.Value = activity.Capacity;
            nmrPrice.Value = activity.Price;

            List<City> citiesComboItems = new List<City>();
            cmbCities.Items.Clear();
            foreach (City city in cityManager.GetAllCities())
            {
                citiesComboItems.Add(city);

            }

            cmbCities.DisplayMember = "Name";
            cmbCities.ValueMember = "Id";
            cmbCities.DataSource = citiesComboItems;
            cmbCities.SelectedIndex = citiesComboItems.FindIndex(c => c.Id == activity.CityId);
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
                if (nmrCapacity.Value < 1) { throw new Exception("Please provide a capacity bigger than 0"); }
                capacity = Convert.ToInt32(nmrCapacity.Value);
                price = nmrPrice.Value;
                activitiesManager.EditActivity(new Activity(activity.Id,city.Id, capacity, name, description, price, new Address(street, postalCode)));
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
