using EI_Task.Data;
using EI_Task.Models;
using EI_Task.Services;


namespace EI_Task
{
    public partial class LoginForm : Form
    {

        private readonly IAccountService _loginService;
        private readonly IUserManagerService _userManagerService;
        private readonly IBookManagerService _bookManagerService;
        private readonly IValidationService _validation;


        public LoginForm(
                     IAccountService loginService
                    , IUserManagerService userManagerService
                    ,IBookManagerService bookManagerService
                    , IValidationService validation)
        {
            _loginService = loginService;
            _userManagerService = userManagerService;
            _bookManagerService = bookManagerService;
            _validation = validation;
            InitializeComponent();
            
        }


        private async void LoginSubmitButton_Click(object sender, EventArgs e)
        {
            string email = TextBoxEmail.Text;
            string password = TextBoxPW.Text;

            int userId = await _loginService.LoginAsync(email, password);

            if (userId != -1)
            {
                ResetAllTextBoxes();
                ShowMainForm();
            }
            else
            {
                loginAttemptFailedLable();
            }
        }

        private void loginAttemptFailedLable()
        {
            LoginStatusLabel.ForeColor = Color.Red;
            LoginStatusLabel.Text = "Login Attempt Failed";
        }

        private void SignUpFormButton_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm(_userManagerService, _validation);
            this.Hide();
            signUpForm.ShowDialog();
            this.Show();

        }

        private void ResetAllTextBoxes()
        {
            TextBoxEmail.Text = String.Empty;
            TextBoxPW.Text = String.Empty;
        }

        private void TextBoxPW_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void ShowMainForm()
        {
            MainForm mainForm = new MainForm(_bookManagerService, _validation);
            this.Hide();
            mainForm.ShowDialog();
            this.Show();
        }
    }
}