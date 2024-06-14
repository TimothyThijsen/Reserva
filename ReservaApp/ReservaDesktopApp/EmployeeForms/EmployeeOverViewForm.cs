using DomainLayer.ServiceClasses;
using DomainLayer;
using ReservaDesktopApp.EmployeeForms;
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

namespace ReservaDesktopApp.EmployeeForms
{
    public partial class EmployeeOverViewForm : Form
    {
        EmployeeManager employeeManager;
        CityManager cityManager;
        RoomManager roomManager;
        Employee? selectedEmployee;
        public EmployeeOverViewForm()
        {
            InitializeComponent();
            employeeManager = Program.ServiceProvider.GetRequiredService<EmployeeManager>();
            cityManager = Program.ServiceProvider.GetRequiredService<CityManager>();
            roomManager = Program.ServiceProvider.GetRequiredService<RoomManager>();
            ShowEmployees();
        }
        private void ShowEmployees()
        {
            lvEmployeeDisplay.Items.Clear();
            try
            {
                foreach (Employee employee in employeeManager.GetAllEmployees())
                {
                    ListViewItem item = new ListViewItem(employee.Id.ToString());
                    item.Tag = employee;
                    item.SubItems.Add(employee.FirstName + " " + employee.LastName);
                    item.SubItems.Add(employee.Email);
                    item.SubItems.Add(employee.Role.ToString());
                    item.SubItems.Add(employee.PhoneNUmber);

                    lvEmployeeDisplay.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        void Form_Closing(object sender, EventArgs e)
        {
            ShowEmployees();
        }


        private void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            EmployeeCreateForm childForm = new EmployeeCreateForm();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ((System.Windows.Forms.Panel)Application.OpenForms["MainForm"]!.Controls["panelDesktopPanel"]!).Controls.Add(childForm);
            childForm.BringToFront();
            childForm.FormClosing += Form_Closing!;
            childForm.Show();

        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not implemented");
            /*if (selectedEmployee == null)
            {
                MessageBox.Show("Select a employee");
                return;
            }
            EditEmployeeForm childForm = new EditEmployeeForm(selectedEmployee);

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ((System.Windows.Forms.Panel)Application.OpenForms["MainForm"]!.Controls["panelDesktopPanel"]!).Controls.Add(childForm);
            childForm.BringToFront();
            childForm.FormClosing += Form_Closing!;
            childForm.Show();*/
        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            if (selectedEmployee == null)
            {
                MessageBox.Show("Select a employee");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    employeeManager.RemoveEmployee(selectedEmployee.Id);
                    ShowEmployees();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void lvEmployeeDisplay_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedEmployee = e.Item!.Tag as Employee;
        }

        private void lvEmployeeDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEmployeeDisplay.SelectedItems.Count == 0)
            {
                selectedEmployee = null;
            }
        }

    }
}
