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
        private Dictionary<string, int> _branchNameAndId = new Dictionary<string, int>();
        private string _originalValue;
        public MainForm(ILibraryService<Book> booksService, ILibraryService<Branch> branchesService)
        {
            _booksService = booksService;
            _branchesService = branchesService;
            InitializeComponent();
            GetListOfBook();

        }

/*        private async Task GetBranchNameAndId()
        {
            _branchNameAndId = await _branchesService.GetBranchNameAndId();

        }*/
        private async void GetListOfBook()
        {
            var books = await _booksService.GetAllAsync();

            BookDataGrid.DataSource = books.ToList();

        }

        private async void BookDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == BookDataGrid.Columns["btnDelete"].Index)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Delete Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int rowIndex = e.RowIndex;
                    int bookId = Convert.ToInt32(BookDataGrid.Rows[rowIndex].Cells[0].Value);

                    await _booksService.DeleteAsync(bookId);

                    GetListOfBook();
                }
            }
        }

        private void BookDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;

            _originalValue = BookDataGrid.Rows[rowIndex].Cells[colIndex].Value.ToString();
        }

        private async void BookDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Get the edited row and column
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;

            // Get the edited book's ID (it's in the first column)
            int bookId = Convert.ToInt32(BookDataGrid.Rows[rowIndex].Cells[0].Value);

            // Get the new value
            object newValue = BookDataGrid.Rows[rowIndex].Cells[colIndex].Value;

            // Find the corresponding book from the data source
            Book editedBook = await _booksService.GetAsync(bookId);

            // Update the edited property
            switch (colIndex)
            {
                case 1:
                    if (String.IsNullOrWhiteSpace(newValue.ToString()))
                    {
                        MessageBox.Show("Invalid input. The name cannot be empty or only spaces.");
                        BookDataGrid.Rows[rowIndex].Cells[colIndex].Value = _originalValue;
                        return;
                    }
                    else
                    {
                        editedBook.Name = newValue.ToString();
                    }
                    break;
                case 2:
                    int newYear;
                    if (int.TryParse(newValue.ToString(), out newYear))
                    {
                        if (ValidatePublishedYear(newYear))
                        {
                            editedBook.PublishedYear = newYear;
                        }
                        else
                        {
                            MessageBox.Show("Invalid year. Please enter a year between 1 and the current year.");
                            BookDataGrid.Rows[rowIndex].Cells[colIndex].Value = _originalValue;
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid year.");
                        BookDataGrid.Rows[rowIndex].Cells[colIndex].Value = _originalValue;
                        return;
                    }
                    break;
                case 3:
                    editedBook.Availability = (bool)newValue;
                    break;
            }

            await _booksService.UpdateAsync(bookId, editedBook);
        }


        private bool ValidatePublishedYear(int year)
        {
            int currentYear = DateTime.Now.Year;
            if (year >= 1 && year <= currentYear && year != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
