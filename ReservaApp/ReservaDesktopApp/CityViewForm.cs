using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.Extensions.DependencyInjection;

namespace ReservaDesktopApp
{
    public partial class CItyViewForm : Form
    {
        CityManager cityManager;
        City? selectedCity;
        int cityEditId;
        public CItyViewForm()
        {
            InitializeComponent();
            cityManager = Program.ServiceProvider.GetRequiredService<CityManager>();
            ShowCities();
        }
        public void ShowCities()
        {
            lvCities.Items.Clear();
            try
            {
                foreach (City city in cityManager.GetAllCities())
                {
                    ListViewItem item = new ListViewItem(city.Id.ToString());
                    item.Tag = city;
                    item.SubItems.Add(city.Name);

                    lvCities.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnSave.Visible = false;
        }

        private void lvCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCities.SelectedItems.Count == 0)
            {
                selectedCity = null;
            }
        }

        private void lvCities_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedCity = e.Item!.Tag as City;
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            string name;
            bool success = false;
            try
            {
                if (txbName.Text == string.Empty) { throw new Exception("Please provide a name"); }
                name = txbName.Text;
                cityManager.AddCity(new City(name));
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (success)
            {
                ShowCities();
            }
        }

        private void btnRemoveCity_Click(object sender, EventArgs e)
        {
            if (selectedCity == null)
            {
                MessageBox.Show("Select a city");
                return;
            }
            try
            {
                cityManager.RemoveCity(selectedCity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name;
            bool success = false;
            try
            {
                if (txbName.Text == string.Empty) { throw new Exception("Please provide a name"); }
                name = txbName.Text;
                cityManager.AddCity(new City(cityEditId, name));
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (success)
            {
                btnClear.PerformClick();
                ShowCities();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbName.Clear();
            btnSave.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCity == null)
            {
                MessageBox.Show("Select a city");
                return;
            }
            cityEditId = selectedCity.Id;
            txbName.Text = selectedCity.Name;
            btnSave.Visible = true;
        }
    }
}
