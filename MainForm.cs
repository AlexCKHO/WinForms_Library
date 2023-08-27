﻿using EI_Task.Models;
using EI_Task.Services;
using System.ComponentModel;
using System.Data;


namespace EI_Task
{
    public partial class MainForm : Form
    {

        private readonly IBookManagerService _bookManagerService;
        private List<Book> _allBooks = new List<Book>();
        private Dictionary<string, int> _branchNameAndId = new Dictionary<string, int>();
        private string _originalValue;
        public MainForm(IBookManagerService bookManagerService)
        {
            _bookManagerService = bookManagerService;
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
            _branchNameAndId = await _bookManagerService.GetBranchNameAndIdAsync();

        }
        private async void GetListOfBook()
        {
            _allBooks = await _bookManagerService.GetListOfBookAsync();
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

                    await _bookManagerService.DeleteBookAsync(bookId);

                    GetListOfBook();
                }
            }
        }

        private void BookDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;

            if (rowIndex != -1)
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
                        await _bookManagerService.UpdateBookName(bookId, newValue.ToString());
                    }
                    break;
                case 2:
                    int newYear;
                    if (int.TryParse(newValue.ToString(), out newYear))
                    {
                        if (Validation.ValidatePublishedYear(newYear))
                        {
                            await _bookManagerService.UpdateBookYear(bookId, newYear);
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
                    await _bookManagerService.UpdateAvailable(bookId, (bool)newValue);
                    break;
            }
            GetListOfBook();

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

            string name = NameTextBox.Text;
            int publishedYear = int.Parse(PublishYearTextBox.Text);
            bool availability = AvailableCheckBox.Checked;
            int branchId = _branchNameAndId.FirstOrDefault(x => x.Key == LocationList.Text).Value;

            return await _bookManagerService.CreateBookAsync(name, publishedYear, availability, branchId);

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

        private void SearchFormButton_Click(object sender, EventArgs e)
        {
            SearchEngineForm form = new SearchEngineForm();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
