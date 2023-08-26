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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            label1 = new Label();
            BookDataGrid = new DataGridView();
            BookId = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            publishedYearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            availabilityDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            BranchId = new DataGridViewTextBoxColumn();
            btnDelete = new DataGridViewButtonColumn();
            bookBindingSource = new BindingSource(components);
            ListOfBranch = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)BookDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bookBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(667, 39);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // BookDataGrid
            // 
            BookDataGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(238, 239, 249);
            BookDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            BookDataGrid.AutoGenerateColumns = false;
            BookDataGrid.BorderStyle = BorderStyle.None;
            BookDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(20, 25, 70);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            BookDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            BookDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BookDataGrid.Columns.AddRange(new DataGridViewColumn[] { BookId, nameDataGridViewTextBoxColumn, publishedYearDataGridViewTextBoxColumn, availabilityDataGridViewCheckBoxColumn, BranchId, btnDelete });
            BookDataGrid.DataSource = bookBindingSource;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.ForestGreen;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            BookDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            BookDataGrid.EnableHeadersVisualStyles = false;
            BookDataGrid.Location = new Point(94, 87);
            BookDataGrid.Name = "BookDataGrid";
            BookDataGrid.RowTemplate.Height = 25;
            BookDataGrid.Size = new Size(546, 506);
            BookDataGrid.TabIndex = 1;
            BookDataGrid.CellClick += BookDataGrid_CellClick;
            BookDataGrid.CellContentClick += BookDataGrid_CellContentClick;
            BookDataGrid.CellEndEdit += BookDataGrid_CellEndEdit;
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
            ListOfBranch.Location = new Point(759, 87);
            ListOfBranch.Name = "ListOfBranch";
            ListOfBranch.Size = new Size(121, 23);
            ListOfBranch.TabIndex = 2;
            ListOfBranch.SelectedValueChanged += ListOfBranch_SelectedValueChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1235, 726);
            Controls.Add(ListOfBranch);
            Controls.Add(BookDataGrid);
            Controls.Add(label1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Page";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)BookDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)bookBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView BookDataGrid;
        private BindingSource bookBindingSource;
        private ComboBox ListOfBranch;
        private DataGridViewTextBoxColumn BookId;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn publishedYearDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn availabilityDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn BranchId;
        private DataGridViewButtonColumn btnDelete;
    }
}