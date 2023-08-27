using EI_Task.Models;
using EI_Task.Services;
using System.ComponentModel;
using System.Data;


namespace EI_Task
{
    public partial class MainForm : Form
    {

        private readonly IBookManagerService _bookManagerService;
        private readonly IValidationService _validationService;
        private List<Book> _allBooks = new List<Book>();
        private Dictionary<string, int> _branchNameAndId = new Dictionary<string, int>();
        private string _originalValue;
        public MainForm(IBookManagerService bookManagerService, IValidationService validationService)
        {
            _bookManagerService = bookManagerService;
            _validationService = validationService;
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
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;

            

            if (e.ColumnIndex == BookDataGrid.Columns["btnDelete"].Index)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Delete Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    rowIndex = e.RowIndex;
                    int bookId = Convert.ToInt32(BookDataGrid.Rows[rowIndex].Cells[0].Value);

                    await _bookManagerService.DeleteBookAsync(bookId);

                    GetListOfBook();
                } 
            }
            else if (rowIndex != -1)
            {
                _originalValue = BookDataGrid.Rows[rowIndex].Cells[colIndex].Value.ToString();
            }
        }


        private async void BookDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            int bookId = Convert.ToInt32(BookDataGrid.Rows[rowIndex].Cells[0].Value);
            object newValue = BookDataGrid.Rows[rowIndex].Cells[colIndex].Value;
            string columnName = BookDataGrid.Columns[colIndex].HeaderText;

            // Validate the new value using the Validation class
            if (!_validationService.ValidateCellValue(columnName, newValue))
            {
                MessageBox.Show("Invalid input.");
                BookDataGrid.Rows[rowIndex].Cells[colIndex].Value = _originalValue;
                return;
            }

            var result = await _bookManagerService.UpdateBookPropertyAsync(bookId, columnName, newValue);
            if (!result)
            {
                MessageBox.Show("Update failed.");
                BookDataGrid.Rows[rowIndex].Cells[colIndex].Value = _originalValue;
            }

            GetListOfBook();
        }

        private async void AddBooksButton_Click(object sender, EventArgs e)
        {
            if (_validationService.MainFormAreAllInputsValid(this.Controls, errorProvider))
            {
                var result = await CreateBook();
                if (result)
                {

                    successfulStatusLabel();
                    GetListOfBook();
                    ResetAllTextBoxes();
                    
                }
            }
            else
            {
                unsuccessfulStatusLabel();
            }
        }

        private void successfulStatusLabel()
        {
            StatusLabel.ForeColor = Color.Green;
            StatusLabel.Text = "Successfully Added New Book";
        }

        private void unsuccessfulStatusLabel()
        {
            StatusLabel.ForeColor = Color.Red;
            StatusLabel.Text = "Please fill in correct information";
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
            MessageBox.Show("Invalid input. The field cannot be empty or space only or Text");
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
            else if (!_validationService.ValidatePublishedYear(PublishYearTextBox.Text))
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
            SearchEngineForm form = new SearchEngineForm(_bookManagerService);
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
