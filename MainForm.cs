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
        private readonly IUserManagerService _userManagerService;
        private List<Book> _allBooks = new List<Book>();
        private Dictionary<string, int> _branchNameAndId = new Dictionary<string, int>();
        private string _originalValue;
        public MainForm(ILibraryService<Book> booksService, IUserManagerService userManagerService)
        {
            _booksService = booksService;
            _userManagerService = userManagerService;
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetListOfBook();
            SetBranchDropList();
        }

        private async void SetBranchDropList()
        {
            await GetBranchNameAndId();
            ListOfBranch.Items.Clear();
            LocationList.Items.Clear();
            LocationList.Items.AddRange(_branchNameAndId.Keys.ToArray());
            ListOfBranch.Items.Add("All");
            ListOfBranch.Items.AddRange(_branchNameAndId.Keys.ToArray());
        }

        private async Task GetBranchNameAndId()
        {
            _branchNameAndId = await _userManagerService.GetBranchNameAndId();

        }
        private async void GetListOfBook()
        {
            _allBooks = (await _booksService.GetAllAsync()).ToList();
            BookDataGrid.DataSource = _allBooks;
        }

        private void ListOfBranch_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ListOfBranch.Text == "All")
            {
                BookDataGrid.DataSource = _allBooks;
            }
            else
            {
                int branchId = _branchNameAndId.FirstOrDefault(x => x.Key == ListOfBranch.Text).Value;
                var filteredBooks = _allBooks.Where(book => book.BranchId == branchId).ToList();
                BookDataGrid.DataSource = filteredBooks;
            }

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

            if(rowIndex != -1 )
            {
                _originalValue = BookDataGrid.Rows[rowIndex].Cells[colIndex].Value.ToString();
            }
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

            if (newValue == null)
            {
                MessageBox.Show("Invalid input. The field cannot be empty");
                BookDataGrid.Rows[rowIndex].Cells[colIndex].Value = _originalValue;
                return;
            }

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
                        if (Validation.ValidatePublishedYear(newYear))
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

        private async void AddBooksButton_Click(object sender, EventArgs e)
        {
            if (Validation.AreAllInputsValid(this.Controls, errorProvider))
            {
                var result = await CreateBook();
                if (result)
                {

                    StatusLabel.ForeColor = Color.Green;
                    StatusLabel.Text = "Successfully Added New Book";
                    ResetAllTextBoxes();
                    GetListOfBook();
                    ListOfBranch.SelectedIndex = 0;
                }
            }
            else
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = "Please fill in correct information";
            }
        }

        private void ResetAllTextBoxes()
        {
            NameTextBox.Text = String.Empty;
            PublishYearTextBox.Text = String.Empty;
            LocationList.SelectedIndex = 0;
        }



        private async Task<bool> CreateBook()
        {
            var book = new Book();
            book.Name = NameTextBox.Text;
            book.PublishedYear = int.Parse(PublishYearTextBox.Text);
            book.Availability = AvailableCheckBox.Checked;
            book.BranchId = _branchNameAndId.FirstOrDefault(x => x.Key == LocationList.Text).Value;

            return await _booksService.CreateAsync(book);

        }

        private void BookDataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Invalid input. The field cannot be empty or space only");
        }

        private void NameTextBox_Validating(object sender, CancelEventArgs e)
        {
            StatusLabel.Text = "";

            if (string.IsNullOrEmpty(NameTextBox.Text) || string.IsNullOrWhiteSpace(NameTextBox.Text))
            {

                errorProvider.SetError(NameTextBox, "Please enter book name !");
            }
            else
            {
                errorProvider.SetError(NameTextBox, null);
            }
        }




        private void PublishYearTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(PublishYearTextBox.Text) || string.IsNullOrWhiteSpace(PublishYearTextBox.Text))
            {

                errorProvider.SetError(PublishYearTextBox, "Please enter Year !");
            }
            else if (!Validation.ValidatePublishedYear(PublishYearTextBox.Text))
            {
                errorProvider.SetError(PublishYearTextBox, "Invalid year. Please enter a year between 1 and the current year.");

            }
            else
            {
                errorProvider.SetError(PublishYearTextBox, null);
            }
        }



    }
}
