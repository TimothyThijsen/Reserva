

using ReservaDesktopApp.EmployeeForms;

namespace ReservaDesktopApp
{
    public partial class MainForm : Form
    {
        private Form? activeForm;
        private Button? currentButton;

        public MainForm()
        {
            InitializeComponent();
            btnCloseChildForm.Visible = false;
        }
        private void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();

                    Color color = Color.FromArgb(55, 159, 255);
                    currentButton = (Button)btnSender;
                    currentButton.ForeColor = Color.White;
                    currentButton.BackColor = color;
                    currentButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);

                }
            }
        }

        private void DisableButton()
        {
            foreach (Control prevBtn in panelMenu.Controls)
            {
                if (prevBtn.GetType() == typeof(Button))
                {
                    prevBtn.BackColor = Color.FromArgb(0, 11, 105);
                    prevBtn.ForeColor = Color.White;
                    prevBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
                }
            }
        }
        public void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActiveButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
            btnCloseChildForm.Visible = true;
        }
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                foreach (Control control in panelDesktopPanel.Controls.OfType<Form>().ToList())
                {
                    this.panelDesktopPanel.Controls.Remove(control);
                }

                Reset();
            }
        }

        private void Reset()
        {
            lblTitle.Text = "HOME";
            btnCloseChildForm.Visible = false;
            DisableButton();
            currentButton = null;
        }

        private void btnCreateMediaForm_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new MediaForm(), sender);
        }

        private void btnHotelOverview_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HotelForms.HotelOverview(), sender);
        }

        private void btnLocationView_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CItyViewForm(), sender);
        }

        private void btnActivity_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ActivitiesOverviewForm(), sender);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EmployeeOverViewForm(), sender);
        }
    }
}
