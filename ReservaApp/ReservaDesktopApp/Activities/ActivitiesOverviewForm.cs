using DomainLayer.ServiceClasses;
using DomainLayer;
using ReservaDesktopApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ReservaDesktopApp.Activities;

namespace ReservaDesktopApp
{
    public partial class ActivitiesOverviewForm : Form
    {
        ActivitiesManager activityManager;
        CityManager cityManager;
        Activity? selectedActivity;
        public ActivitiesOverviewForm()
        {
            InitializeComponent();
            activityManager = Program.ServiceProvider.GetRequiredService<ActivitiesManager>();
            cityManager = Program.ServiceProvider.GetRequiredService<CityManager>();
            ShowActivities();
        }
        private void ShowActivities()
        {
            lvActivityDisplay.Items.Clear();
            try
            {
                foreach (Activity activity in activityManager.GetActivities())
                {
                    ListViewItem item = new ListViewItem(activity.Id.ToString());
                    item.Tag = activity;
                    item.SubItems.Add(activity.Name);
                    item.SubItems.Add(activity.Price.ToString("€0.00"));
                    item.SubItems.Add(cityManager.GetCity(activity.CityId).Name);
                    item.SubItems.Add(activity.Capacity.ToString());

                    lvActivityDisplay.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        void Form_Closing(object sender, EventArgs e)
        {
            ShowActivities();
        }


        private void btnCreateActivity_Click(object sender, EventArgs e)
        {
            CreateActivitiesForm childForm = new CreateActivitiesForm();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ((System.Windows.Forms.Panel)Application.OpenForms["MainForm"]!.Controls["panelDesktopPanel"]!).Controls.Add(childForm);
            childForm.BringToFront();
            childForm.FormClosing += Form_Closing!;
            childForm.Show();

        }

        private void btnEditActivity_Click(object sender, EventArgs e)
        {
            if (selectedActivity == null)
            {
                MessageBox.Show("Select a activity");
                return;
            }
            EditActivityForm childForm = new EditActivityForm(selectedActivity);

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ((System.Windows.Forms.Panel)Application.OpenForms["MainForm"]!.Controls["panelDesktopPanel"]!).Controls.Add(childForm);
            childForm.BringToFront();
            childForm.FormClosing += Form_Closing!;
            childForm.Show();
        }

        private void btnRemoveActivity_Click(object sender, EventArgs e)
        {
            if (selectedActivity == null)
            {
                MessageBox.Show("Select a activity");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    activityManager.RemoveActivity(selectedActivity);
                    ShowActivities();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void lvActivityDisplay_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedActivity = e.Item!.Tag as Activity;
        }

        private void lvActivityDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvActivityDisplay.SelectedItems.Count == 0)
            {
                selectedActivity = null;
            }
        }

        
    }
}
