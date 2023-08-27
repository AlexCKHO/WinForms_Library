namespace EI_Task
{
    partial class SearchEngineForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            searchItemList = new DataGridView();
            bookIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            branchIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bookNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            publishedYearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            availabilityDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            branchNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            branchLocationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            openingHoursDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bookSearchResultDTOBindingSource = new BindingSource(components);
            SearchTextBox = new TextBox();
            SearchButton = new Button();
            MainPageBotton = new Button();
            SearchResultNotFoundLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)searchItemList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bookSearchResultDTOBindingSource).BeginInit();
            SuspendLayout();
            // 
            // searchItemList
            // 
            searchItemList.AllowUserToAddRows = false;
            searchItemList.AllowUserToDeleteRows = false;
            searchItemList.AutoGenerateColumns = false;
            searchItemList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            searchItemList.Columns.AddRange(new DataGridViewColumn[] { bookIdDataGridViewTextBoxColumn, branchIdDataGridViewTextBoxColumn, bookNameDataGridViewTextBoxColumn, publishedYearDataGridViewTextBoxColumn, availabilityDataGridViewCheckBoxColumn, branchNameDataGridViewTextBoxColumn, branchLocationDataGridViewTextBoxColumn, openingHoursDataGridViewTextBoxColumn });
            searchItemList.DataSource = bookSearchResultDTOBindingSource;
            searchItemList.Location = new Point(70, 143);
            searchItemList.Name = "searchItemList";
            searchItemList.ReadOnly = true;
            searchItemList.RowTemplate.Height = 25;
            searchItemList.Size = new Size(643, 456);
            searchItemList.TabIndex = 0;
            // 
            // bookIdDataGridViewTextBoxColumn
            // 
            bookIdDataGridViewTextBoxColumn.DataPropertyName = "BookId";
            bookIdDataGridViewTextBoxColumn.HeaderText = "BookId";
            bookIdDataGridViewTextBoxColumn.Name = "bookIdDataGridViewTextBoxColumn";
            bookIdDataGridViewTextBoxColumn.ReadOnly = true;
            bookIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // branchIdDataGridViewTextBoxColumn
            // 
            branchIdDataGridViewTextBoxColumn.DataPropertyName = "BranchId";
            branchIdDataGridViewTextBoxColumn.HeaderText = "BranchId";
            branchIdDataGridViewTextBoxColumn.Name = "branchIdDataGridViewTextBoxColumn";
            branchIdDataGridViewTextBoxColumn.ReadOnly = true;
            branchIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // bookNameDataGridViewTextBoxColumn
            // 
            bookNameDataGridViewTextBoxColumn.DataPropertyName = "BookName";
            bookNameDataGridViewTextBoxColumn.HeaderText = "BookName";
            bookNameDataGridViewTextBoxColumn.Name = "bookNameDataGridViewTextBoxColumn";
            bookNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // publishedYearDataGridViewTextBoxColumn
            // 
            publishedYearDataGridViewTextBoxColumn.DataPropertyName = "PublishedYear";
            publishedYearDataGridViewTextBoxColumn.HeaderText = "PublishedYear";
            publishedYearDataGridViewTextBoxColumn.Name = "publishedYearDataGridViewTextBoxColumn";
            publishedYearDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // availabilityDataGridViewCheckBoxColumn
            // 
            availabilityDataGridViewCheckBoxColumn.DataPropertyName = "Availability";
            availabilityDataGridViewCheckBoxColumn.HeaderText = "Availability";
            availabilityDataGridViewCheckBoxColumn.Name = "availabilityDataGridViewCheckBoxColumn";
            availabilityDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // branchNameDataGridViewTextBoxColumn
            // 
            branchNameDataGridViewTextBoxColumn.DataPropertyName = "BranchName";
            branchNameDataGridViewTextBoxColumn.HeaderText = "BranchName";
            branchNameDataGridViewTextBoxColumn.Name = "branchNameDataGridViewTextBoxColumn";
            branchNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // branchLocationDataGridViewTextBoxColumn
            // 
            branchLocationDataGridViewTextBoxColumn.DataPropertyName = "BranchLocation";
            branchLocationDataGridViewTextBoxColumn.HeaderText = "BranchLocation";
            branchLocationDataGridViewTextBoxColumn.Name = "branchLocationDataGridViewTextBoxColumn";
            branchLocationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // openingHoursDataGridViewTextBoxColumn
            // 
            openingHoursDataGridViewTextBoxColumn.DataPropertyName = "OpeningHours";
            openingHoursDataGridViewTextBoxColumn.HeaderText = "OpeningHours";
            openingHoursDataGridViewTextBoxColumn.Name = "openingHoursDataGridViewTextBoxColumn";
            openingHoursDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bookSearchResultDTOBindingSource
            // 
            bookSearchResultDTOBindingSource.DataSource = typeof(Models.DTO.BookSearchResultDTO);
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(72, 98);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.PlaceholderText = "Enter a book name";
            SearchTextBox.Size = new Size(525, 23);
            SearchTextBox.TabIndex = 1;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(631, 97);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(75, 23);
            SearchButton.TabIndex = 2;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // MainPageBotton
            // 
            MainPageBotton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            MainPageBotton.Location = new Point(23, 24);
            MainPageBotton.Name = "MainPageBotton";
            MainPageBotton.Size = new Size(86, 34);
            MainPageBotton.TabIndex = 3;
            MainPageBotton.Text = "Go Back";
            MainPageBotton.UseVisualStyleBackColor = true;
            MainPageBotton.Click += MainPageBotton_Click;
            // 
            // SearchResultNotFoundLabel
            // 
            SearchResultNotFoundLabel.AutoSize = true;
            SearchResultNotFoundLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            SearchResultNotFoundLabel.Location = new Point(200, 35);
            SearchResultNotFoundLabel.Name = "SearchResultNotFoundLabel";
            SearchResultNotFoundLabel.Size = new Size(0, 30);
            SearchResultNotFoundLabel.TabIndex = 4;
            // 
            // SearchEngineForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(793, 686);
            Controls.Add(SearchResultNotFoundLabel);
            Controls.Add(MainPageBotton);
            Controls.Add(SearchButton);
            Controls.Add(SearchTextBox);
            Controls.Add(searchItemList);
            Name = "SearchEngineForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SearchEngineForm";
            Load += SearchEngineForm_Load;
            ((System.ComponentModel.ISupportInitialize)searchItemList).EndInit();
            ((System.ComponentModel.ISupportInitialize)bookSearchResultDTOBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView searchItemList;
        private DataGridViewTextBoxColumn bookIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn branchIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bookNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn publishedYearDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn availabilityDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn branchNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn branchLocationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn openingHoursDataGridViewTextBoxColumn;
        private BindingSource bookSearchResultDTOBindingSource;
        private TextBox SearchTextBox;
        private Button SearchButton;
        private Button MainPageBotton;
        private Label SearchResultNotFoundLabel;
    }
}