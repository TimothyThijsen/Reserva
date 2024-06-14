using DomainLayer.ServiceClasses;
using DomainLayer;
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
using Enums;

namespace ReservaDesktopApp.EmployeeForms
{
    public partial class EmployeeCreateForm : Form
    {
        CityManager cityManager;
        EmployeeManager employeeManager;
        public EmployeeCreateForm()
        {
            InitializeComponent();
            employeeManager = Program.ServiceProvider.GetRequiredService<EmployeeManager>();
            cityManager = Program.ServiceProvider.GetRequiredService<CityManager>();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string firstName;
            string lastName;
            string email;
            DateOnly dateOfBirth;
            string password;
            decimal salary;
            string phoneNumber;
            EmployeeRole role;
            bool success = false;
            try
            {
                if (txbFName.Text == string.Empty) { throw new Exception("Please provide a firstName"); }
                firstName = txbFName.Text;
                if (txbLName.Text == string.Empty) throw new Exception("Please provide a lastName");
                lastName = txbLName.Text;
                if (txbEmail.Text == string.Empty) { throw new Exception("Please provide an email"); }
                email = txbEmail.Text;
                if (txbPassword.Text == string.Empty) { throw new Exception("Please provide a password"); }
                password = txbPassword.Text;
                dateOfBirth = DateOnly.FromDateTime(dtpDateOfbirth.Value);
                salary = nmrSalary.Value;
                phoneNumber = txbPhoneNumber.Text;
                role = (EmployeeRole)cmbRole.SelectedIndex;
                employeeManager.AddEmployee(new Employee(firstName,lastName,email,dateOfBirth,password,salary,phoneNumber,role));
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
