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

namespace EI_Task
{
    public partial class MainForm : Form
    {
        private readonly ILibraryService<Book> _booksService;
        private readonly ILibraryService<Branch> _branchesService;
        public MainForm(ILibraryService<Book> booksService, ILibraryService<Branch> branchesService)
        {
            _booksService = booksService;
            _branchesService = branchesService;
            InitializeComponent();
            GetListOfBook();

        }


        private async void GetListOfBook()
        {
            var books = await _booksService.GetAllAsync();
            var branches = await _branchesService.GetAllAsync();

            var bookData = from book in books
                           join branch in branches on book.BranchId equals branch.BranchId
                           select new
                           {
                               book.Name,
                               book.PublishedYear,
                               book.Availability,
                               BranchName = branch.BranchName
                           };


            BookDataGrid.DataSource = bookData.ToList();

        }

        private void BookDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
