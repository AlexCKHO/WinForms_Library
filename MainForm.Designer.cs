namespace EI_Task
{
    partial class MainForm
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            BookDataGrid = new DataGridView();
            BookId = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            publishedYearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            availabilityDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            BranchId = new DataGridViewTextBoxColumn();
            btnDelete = new DataGridViewButtonColumn();
            bookBindingSource = new BindingSource(components);
            ListOfBranch = new ComboBox();
            NameTextBox = new TextBox();
            PublishYearTextBox = new TextBox();
            AvailableCheckBox = new CheckBox();
            LocationList = new ComboBox();
            AddBooksButton = new Button();
            errorProvider = new ErrorProvider(components);
            StatusLabel = new Label();
            label1 = new Label();
            SearchFormButton = new Button();
            LogOutButton = new Button();
            ((System.ComponentModel.ISupportInitialize)BookDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bookBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // BookDataGrid
            // 
            BookDataGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(238, 239, 249);
            BookDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            BookDataGrid.AutoGenerateColumns = false;
            BookDataGrid.BorderStyle = BorderStyle.None;
            BookDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(20, 25, 70);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            BookDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            BookDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BookDataGrid.Columns.AddRange(new DataGridViewColumn[] { BookId, nameDataGridViewTextBoxColumn, publishedYearDataGridViewTextBoxColumn, availabilityDataGridViewCheckBoxColumn, BranchId, btnDelete });
            BookDataGrid.DataSource = bookBindingSource;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = Color.ForestGreen;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            BookDataGrid.DefaultCellStyle = dataGridViewCellStyle6;
            BookDataGrid.EnableHeadersVisualStyles = false;
            BookDataGrid.Location = new Point(192, 140);
            BookDataGrid.Name = "BookDataGrid";
            BookDataGrid.RowTemplate.Height = 25;
            BookDataGrid.Size = new Size(546, 506);
            BookDataGrid.TabIndex = 1;
            BookDataGrid.CellClick += BookDataGrid_CellClick;
            BookDataGrid.CellContentClick += BookDataGrid_CellContentClick;
            BookDataGrid.CellEndEdit += BookDataGrid_CellEndEdit;
            BookDataGrid.DataError += BookDataGrid_DataError;
            // 
            // BookId
            // 
            BookId.DataPropertyName = "BookId";
            BookId.HeaderText = "BookId";
            BookId.Name = "BookId";
            BookId.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // publishedYearDataGridViewTextBoxColumn
            // 
            publishedYearDataGridViewTextBoxColumn.DataPropertyName = "PublishedYear";
            publishedYearDataGridViewTextBoxColumn.HeaderText = "PublishedYear";
            publishedYearDataGridViewTextBoxColumn.Name = "publishedYearDataGridViewTextBoxColumn";
            // 
            // availabilityDataGridViewCheckBoxColumn
            // 
            availabilityDataGridViewCheckBoxColumn.DataPropertyName = "Availability";
            availabilityDataGridViewCheckBoxColumn.HeaderText = "Availability";
            availabilityDataGridViewCheckBoxColumn.Name = "availabilityDataGridViewCheckBoxColumn";
            // 
            // BranchId
            // 
            BranchId.DataPropertyName = "BranchId";
            BranchId.HeaderText = "Branch Id";
            BranchId.Name = "BranchId";
            BranchId.ReadOnly = true;
            // 
            // btnDelete
            // 
            btnDelete.HeaderText = "Delete";
            btnDelete.Name = "btnDelete";
            btnDelete.Text = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;
            // 
            // bookBindingSource
            // 
            bookBindingSource.DataSource = typeof(Models.Book);
            // 
            // ListOfBranch
            // 
            ListOfBranch.FormattingEnabled = true;
            ListOfBranch.Location = new Point(29, 164);
            ListOfBranch.Name = "ListOfBranch";
            ListOfBranch.Size = new Size(121, 23);
            ListOfBranch.TabIndex = 2;
            ListOfBranch.SelectedValueChanged += ListOfBranch_SelectedValueChanged;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(213, 87);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.PlaceholderText = "Name";
            NameTextBox.Size = new Size(89, 23);
            NameTextBox.TabIndex = 3;
            NameTextBox.Validating += NameTextBox_Validating;
            // 
            // PublishYearTextBox
            // 
            PublishYearTextBox.Location = new Point(338, 87);
            PublishYearTextBox.Name = "PublishYearTextBox";
            PublishYearTextBox.PlaceholderText = "Publish Year";
            PublishYearTextBox.Size = new Size(89, 23);
            PublishYearTextBox.TabIndex = 4;
            PublishYearTextBox.Validating += PublishYearTextBox_Validating;
            // 
            // AvailableCheckBox
            // 
            AvailableCheckBox.AutoSize = true;
            AvailableCheckBox.Location = new Point(448, 89);
            AvailableCheckBox.Name = "AvailableCheckBox";
            AvailableCheckBox.Size = new Size(74, 19);
            AvailableCheckBox.TabIndex = 5;
            AvailableCheckBox.Text = "Available";
            AvailableCheckBox.UseVisualStyleBackColor = true;
            // 
            // LocationList
            // 
            LocationList.FormattingEnabled = true;
            LocationList.Location = new Point(528, 87);
            LocationList.Name = "LocationList";
            LocationList.Size = new Size(89, 23);
            LocationList.TabIndex = 6;
            // 
            // AddBooksButton
            // 
            AddBooksButton.Location = new Point(647, 87);
            AddBooksButton.Name = "AddBooksButton";
            AddBooksButton.Size = new Size(75, 23);
            AddBooksButton.TabIndex = 7;
            AddBooksButton.Text = "Add Book";
            AddBooksButton.UseVisualStyleBackColor = true;
            AddBooksButton.Click += AddBooksButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            StatusLabel.Location = new Point(230, 24);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(0, 40);
            StatusLabel.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(18, 130);
            label1.Name = "label1";
            label1.Size = new Size(142, 19);
            label1.TabIndex = 9;
            label1.Text = "Filter Book By Branch";
            // 
            // SearchFormButton
            // 
            SearchFormButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SearchFormButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            SearchFormButton.Location = new Point(29, 372);
            SearchFormButton.Name = "SearchFormButton";
            SearchFormButton.Size = new Size(131, 46);
            SearchFormButton.TabIndex = 10;
            SearchFormButton.Text = "Search Book Name";
            SearchFormButton.UseVisualStyleBackColor = true;
            SearchFormButton.Click += SearchFormButton_Click;
            // 
            // LogOutButton
            // 
            LogOutButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            LogOutButton.Location = new Point(55, 24);
            LogOutButton.Name = "LogOutButton";
            LogOutButton.Size = new Size(75, 32);
            LogOutButton.TabIndex = 11;
            LogOutButton.Text = "Log out";
            LogOutButton.UseVisualStyleBackColor = true;
            LogOutButton.Click += LogOutButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(793, 686);
            Controls.Add(LogOutButton);
            Controls.Add(SearchFormButton);
            Controls.Add(label1);
            Controls.Add(StatusLabel);
            Controls.Add(AddBooksButton);
            Controls.Add(LocationList);
            Controls.Add(AvailableCheckBox);
            Controls.Add(PublishYearTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(ListOfBranch);
            Controls.Add(BookDataGrid);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Page";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)BookDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)bookBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView BookDataGrid;
        private BindingSource bookBindingSource;
        private ComboBox ListOfBranch;
        private DataGridViewTextBoxColumn BookId;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn publishedYearDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn availabilityDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn BranchId;
        private DataGridViewButtonColumn btnDelete;
        private TextBox NameTextBox;
        private TextBox PublishYearTextBox;
        private CheckBox AvailableCheckBox;
        private ComboBox LocationList;
        private Button AddBooksButton;
        private ErrorProvider errorProvider;
        private Label StatusLabel;
        private Label label1;
        private Button SearchFormButton;
        private Button LogOutButton;
    }
}