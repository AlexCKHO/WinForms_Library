using EI_Task.Data;
using EI_Task.Models;
using EI_Task.Services;
using Microsoft.EntityFrameworkCore;

namespace EI_Task
{
    public partial class Form1 : Form
    {
        private readonly ILibraryService<Book> _libraryService;
   //     private readonly ILibraryService<Branch> _branchService;

        public Form1(ILibraryService<Book> libraryService
           // , ILibraryService<Branch> branchService
            )
        {
            _libraryService = libraryService;
        //    _branchService = branchService;
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            label1TextChange();

        }
        private async void label1TextChange()
        {
            var book = await _libraryService.GetAsync(1);
            if (book != null)
            {
                label1.Text = book.Name;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}