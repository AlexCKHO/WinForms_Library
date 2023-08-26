using EI_Task.Data;
using EI_Task.Models;
using EI_Task.Services;
using Microsoft.EntityFrameworkCore;

namespace EI_Task
{
    public partial class LoginForm : Form
    {
        private readonly ILibraryService<Book> _libraryService;
        private readonly IAccountService _loginService;


        public LoginForm(ILibraryService<Book> libraryService
                    , IAccountService loginService
            )
        {
            _libraryService = libraryService;
            _loginService = loginService;
            //    _branchService = branchService;
            InitializeComponent();
            _loginService = loginService;
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


    }
}