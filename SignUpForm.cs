using EI_Task.Services;
using System.ComponentModel;
using System.Text.RegularExpressions;


namespace EI_Task
{
    public partial class SignUpForm : Form
    {
        private readonly IUserManagerService _userManagerService;
        private readonly IValidationService _validationService;
        private Dictionary<string, int> _branchNameAndId = new Dictionary<string, int>();
        public SignUpForm(IUserManagerService userManagerService, IValidationService validationService)
        {
            _userManagerService = userManagerService;
            _validationService = validationService;
            InitializeComponent();
            
        }

        private async void SignUpForm_Load(object sender, EventArgs e)
        {
            await setUpListOfBranch();
        }

        private async Task setUpListOfBranch()
        {
            await GetBranchNameAndId();
            ListOfBranch.Items.Clear();
            ListOfBranch.Items.AddRange(_branchNameAndId.Keys.ToArray());
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            if (_validationService.SignUpFormAreAllInputsValid(this.Controls, errorProvider))
            {
                if (await _userManagerService.hasDuplicateEmail(EmailTextBox.Text))
                {
                    duplicateEmail();
                    return;
                }

                var result = await CreateUser();
                if (result)
                {
                    successfulRegister();
                    ResetAllTextBoxes();
                    
                }
            }
            else
            {
                unsuccessfulRegister();
            }

        }

        private void successfulRegister()
        {
            StatusLabel.ForeColor = Color.Green;
            StatusLabel.Text = "Successfully Registered";
        }

        private void unsuccessfulRegister()
        {
            StatusLabel.ForeColor = Color.Red;
            StatusLabel.Text = "Please fill in correct information";
        }
        private void duplicateEmail()
        {
            StatusLabel.ForeColor = Color.Red;
            StatusLabel.Text = "Email Already exists";
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

                errorProvider.SetError(NameTextBox, "Please enter your name !");
            }
            else
            {

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
            ListOfBranch.SelectedIndex = 0;

        }



       

        private void EmailTextBox_Validating(object sender, CancelEventArgs e)
        {
            string email = EmailTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(email))
            {

                errorProvider.SetError(EmailTextBox, "Please enter an email address!");
            }
            else if (!_validationService.ValidatingEmailInput(email))
            {
                errorProvider.SetError(EmailTextBox, "Invalid email format!");
            }
            else
            {
                errorProvider.SetError(EmailTextBox, null);
            }
        }

        private void PasswordTextBox_Validating(object sender, CancelEventArgs e)
        {
            string password = PasswordTextBox.Text;

            if (!_validationService.ValidatingPasswordInput(password))
            {

                errorProvider.SetError(PasswordTextBox, "Password must not contain spaces, and should have at least 7 characters, 2 numbers, and a special character!");
            }
            else
            {

                errorProvider.SetError(PasswordTextBox, null);
            }

        }

        private void AddressTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(AddressTextBox.Text))
            {

                errorProvider.SetError(AddressTextBox, "Please enter your address !");
            }
            else
            {
                errorProvider.SetError(AddressTextBox, null);
            }
        }

        private void ListOfBranch_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(ListOfBranch.Text))
            {

                errorProvider.SetError(ListOfBranch, "Please Select a branch!");
            }
            else
            {

                errorProvider.SetError(ListOfBranch, null);
            }
        }


        private void DateTextBox_Validating(object sender, CancelEventArgs e)
        {
            StatusLabel.Text = "";
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
                if (_validationService.IsValidDate(day, month, year))
                {
                    errorProvider.SetError(DateTextBox, null);
                    errorProvider.SetError(MonthTextBox, null);
                    errorProvider.SetError(YearTextBox, null);
                }
                else
                {
                    errorProvider.SetError(DateTextBox, "Invalid date.");
                    errorProvider.SetError(MonthTextBox, "Invalid month.");
                    errorProvider.SetError(YearTextBox, "Invalid year.");
                }
            }
            else
            {
                errorProvider.SetError(DateTextBox, "Please enter a valid day.");
                errorProvider.SetError(MonthTextBox, "Please enter a valid month.");
                errorProvider.SetError(YearTextBox, "Please enter a valid year.");
            }
        }





    }
}
