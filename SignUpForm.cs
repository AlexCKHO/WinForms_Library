﻿using EI_Task.Models;
using EI_Task.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            await GetBranchNameAndId();
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
            int branchId = _branchNameAndId.FirstOrDefault(x => x.Key == ListOfBranch.Text).Value;

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
                errorProvider.SetError(NameTextBox, "Please enter your name !");
            }
            else
            {
                EntryError = false;
                errorProvider.SetError(NameTextBox, null);
            }

        }

        private async Task GetBranchNameAndId()
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
            ListOfBranch.SelectedIndex =0;
        }


        private void ListOfBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void EmailTextBox_Validating(object sender, CancelEventArgs e)
        {
            string email = EmailTextBox.Text;

            // Regular expression for validating email
            string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";

            if (string.IsNullOrWhiteSpace(email))
            {
                EntryError = true;
                errorProvider.SetError(EmailTextBox, "Please enter an email address!");
            }
            else if (!Regex.IsMatch(email, pattern))
            {
                EntryError = true;
                errorProvider.SetError(EmailTextBox, "Invalid email format!");
            }
            else
            {
                EntryError = false;
                errorProvider.SetError(EmailTextBox, null);
            }
        }

        private void PasswordTextBox_Validating(object sender, CancelEventArgs e)
        {
            string password = PasswordTextBox.Text;

             if (!Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d\d)(?=.*[@$!%*#?&.])[^ ]{7,}$"))
            {
                EntryError = true;
                errorProvider.SetError(PasswordTextBox, "Password must not contain spaces, and should have at least 7 characters, 2 numbers, and a special character!");
            }
            else
            {
                EntryError = false;
                errorProvider.SetError(PasswordTextBox, null);
            }

        }

        private void AddressTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(AddressTextBox.Text))
            {
                EntryError = true;
                errorProvider.SetError(AddressTextBox, "Please enter your address !");
            }
            else
            {
                EntryError = false;
                errorProvider.SetError(AddressTextBox, null);
            }
        }

        private void ListOfBranch_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(ListOfBranch.Text))
            {
                EntryError = true;
                errorProvider.SetError(ListOfBranch, "Please Select a branch!");
            }
            else
            {
                EntryError = false;
                errorProvider.SetError(ListOfBranch, null);
            }
        }


        private void DateTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateDate();
        }

        private void MonthTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateDate();
        }

        private void YearTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateDate();
        }

        private void ValidateDate()
        {
            if (int.TryParse(DateTextBox.Text, out int day) &&
                int.TryParse(MonthTextBox.Text, out int month) &&
                int.TryParse(YearTextBox.Text, out int year))
            {
                if (IsValidDate(day, month, year))
                {
                    EntryError = false;
                    errorProvider.SetError(DateTextBox, null);
                    errorProvider.SetError(MonthTextBox, null);
                    errorProvider.SetError(YearTextBox, null);
                }
                else
                {
                    EntryError = true;
                    errorProvider.SetError(DateTextBox, "Invalid date.");
                    errorProvider.SetError(MonthTextBox, "Invalid month.");
                    errorProvider.SetError(YearTextBox, "Invalid year.");
                }
            }
            else
            {
                EntryError = true;
                errorProvider.SetError(DateTextBox, "Please enter a valid day.");
                errorProvider.SetError(MonthTextBox, "Please enter a valid month.");
                errorProvider.SetError(YearTextBox, "Please enter a valid year.");
            }
        }

        private bool IsValidDate(int day, int month, int year)
        {
            // Check if year, month and day form a valid date
            if (year < 1900 || year > DateTime.Now.Year)
            {
                return false;
            }

            if (month < 1 || month > 12)
            {
                return false;
            }

            int maxDay = DateTime.DaysInMonth(year, month);

            if (day < 1 || day > maxDay)
            {
                return false;
            }

            return true;
        }
    }
}
