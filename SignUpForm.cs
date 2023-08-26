using EI_Task.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EI_Task
{
    public partial class SignUpForm : Form
    {
        private readonly IUserManagerService _userManagerService;
        private bool EntryError = true;
        private Dictionary<string, int> _branchNameAndId = new Dictionary<string, int>();
        public SignUpForm(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
            InitializeComponent();
        }

        private async void SignUpForm_Load(object sender, EventArgs e)
        {
            await GetListOfBranchId();
            ListOfBranch.Items.Clear();
            ListOfBranch.Items.AddRange(_branchNameAndId.Keys.ToArray());
        }



        private async void SubmitButton_Click(object sender, EventArgs e)
        {

            if (!EntryError)
            {

                var result = await CreateUser();

                if (result)
                {
                    ResetAllTextBoxes();
                }
            }

        }

        private async Task<bool> CreateUser()
        {
            string name = NameTextBox.Text;
            DateTime DOB = DateTime.Parse($"{YearTextBox.Text}-{MonthTextBox.Text}-{DateTextBox.Text}");
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;
            string address = AddressTextBox.Text;
            int branchId = int.Parse(ListOfBranch.Text);

            return await _userManagerService.CreateUserAndAccount(name, DOB, email, address, branchId, password);

        }
       


        private void BackToLoginButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                EntryError = true;
                e.Cancel = true;
                errorProvider.SetError(NameTextBox, "Please enter your name !");
            }
            else
            {
                EntryError = false;
                e.Cancel = false;
                errorProvider.SetError(NameTextBox, null);
            }

        }

        private async Task GetListOfBranchId()
        {
            _branchNameAndId = await _userManagerService.GetBranchNameAndId();

        }
        private void ResetAllTextBoxes()
        {
            NameTextBox.Text = String.Empty;
            YearTextBox.Text = String.Empty;
            MonthTextBox.Text = String.Empty;
            DateTextBox.Text = String.Empty;
            EmailTextBox.Text = String.Empty;
            PasswordTextBox.Text = String.Empty;
            AddressTextBox.Text = String.Empty;
            PMBTextBox.Text = String.Empty;
        }

    }
}
