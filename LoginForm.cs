using EI_Task.Data;
using EI_Task.Models;
using EI_Task.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace EI_Task
{
    public partial class LoginForm : Form
    {
        private readonly ILibraryService<Book> _booksService;
        private readonly ILibraryService<Branch> _branchesService;
        private readonly IAccountService _loginService;
        private readonly IUserManagerService _userManagerService;


        public LoginForm(ILibraryService<Book> booksService
                    , IAccountService loginService
                    , IUserManagerService userManagerService
                    ,ILibraryService<Branch> branchesService

            )
        {
            _booksService = booksService;
            _branchesService = branchesService;
            _loginService = loginService;
            _userManagerService = userManagerService;
            InitializeComponent();
           
        }


        private async void LoginForm_Load(object sender, EventArgs e)
        {


        }



        private async void LoginSubmitButton_Click(object sender, EventArgs e)
        {
            string email = TextBoxEmail.Text.ToLower();
            string password = TextBoxPW.Text.ToLower();

            int userId = await _loginService.LoginAsync(email, password);

            if (userId != -1)
            {
                MainForm mainForm = new MainForm(_booksService,_branchesService);
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                LoginStatusLabel.ForeColor = Color.Red;
                LoginStatusLabel.Text = "Login Attempt Failed";
            }
        }

        private void SignUpFormButton_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm(_userManagerService);
            this.Hide();
            signUpForm.ShowDialog();
            this.Show();

        }

        private void TextBoxPW_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
    }
}