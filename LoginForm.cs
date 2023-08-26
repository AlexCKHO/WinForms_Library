using EI_Task.Data;
using EI_Task.Models;
using EI_Task.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace EI_Task
{
    public partial class LoginForm : Form
    {
        private readonly ILibraryService<Book> _libraryService;
        private readonly IAccountService _loginService;
        private readonly IUserManagerService _userManagerService;


        public LoginForm(ILibraryService<Book> libraryService
                    , IAccountService loginService
                    , IUserManagerService userManagerService
            )
        {
            _libraryService = libraryService;
            _loginService = loginService;
            _userManagerService = userManagerService;
            InitializeComponent();
            
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            label1TextChange();

        }
        private async void label1TextChange() //testing purpose 
        {
            var book = await _libraryService.GetAsync(1);
            if (book != null)
            {
                label1.Text = book.Name;
            }
        }


        private async void LoginSubmitButton_Click(object sender, EventArgs e)
        {
            string email = TextBoxEmail.Text.ToLower();
            string password = TextBoxPW.Text.ToLower();

            int userId = await _loginService.LoginAsync(email, password);

            if (userId != -1)
            {
                MainForm form2 = new MainForm(userId);
                this.Hide();
                form2.ShowDialog();
                this.Close();
            }
            else
            {
                label2.Text = "Login Attempt Failed";
            }
        }

        private void SignUpFormButton_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm(_userManagerService);
            this.Hide();
            signUpForm.ShowDialog();
            this.Show();
            
        }
    }
}