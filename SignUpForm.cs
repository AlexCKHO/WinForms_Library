using EI_Task.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EI_Task
{
    public partial class SignUpForm : Form
    {
        private readonly IUserManagerService _userManagerService;
        public SignUpForm(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
            InitializeComponent();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            DateTime DOB = DateTime.Parse($"{YearTextBox.Text}-{MonthTextBox.Text}-{DateTextBox.Text}");
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;
            string address = AddressTextBox.Text;
            int branchId = int.Parse(PMBTextBox.Text);

            _userManagerService.CreateUserAndAccount(name, DOB, email, address, branchId, password);


        }

        private void BackToLoginButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
