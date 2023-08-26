namespace EI_Task
{
    partial class SignUpForm
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
            NameTextBox = new TextBox();
            DateTextBox = new TextBox();
            EmailTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            AddressTextBox = new TextBox();
            NameLabel = new Label();
            AddressLable = new Label();
            EmailLabel = new Label();
            DOBLabel = new Label();
            PMBLabel = new Label();
            PasswordLable = new Label();
            SubmitButton = new Button();
            MonthTextBox = new TextBox();
            YearTextBox = new TextBox();
            BackToLoginButton = new Button();
            errorProvider = new ErrorProvider(components);
            ListOfBranch = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(154, 97);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(208, 23);
            NameTextBox.TabIndex = 0;
            NameTextBox.Validating += NameTextBox_Validating;
            // 
            // DateTextBox
            // 
            DateTextBox.Location = new Point(154, 142);
            DateTextBox.Name = "DateTextBox";
            DateTextBox.PlaceholderText = "DD";
            DateTextBox.Size = new Size(56, 23);
            DateTextBox.TabIndex = 1;
            DateTextBox.Validating += DateTextBox_Validating;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(154, 186);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(208, 23);
            EmailTextBox.TabIndex = 2;
            EmailTextBox.Validating += EmailTextBox_Validating;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(154, 232);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Size = new Size(208, 23);
            PasswordTextBox.TabIndex = 4;
            PasswordTextBox.Validating += PasswordTextBox_Validating;
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(521, 95);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(208, 23);
            AddressTextBox.TabIndex = 3;
            AddressTextBox.Validating += AddressTextBox_Validating;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NameLabel.Location = new Point(95, 97);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(59, 21);
            NameLabel.TabIndex = 6;
            NameLabel.Text = "Name :";
            // 
            // AddressLable
            // 
            AddressLable.AutoSize = true;
            AddressLable.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddressLable.Location = new Point(448, 95);
            AddressLable.Name = "AddressLable";
            AddressLable.Size = new Size(73, 21);
            AddressLable.TabIndex = 7;
            AddressLable.Text = "Address :";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EmailLabel.Location = new Point(95, 186);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(59, 21);
            EmailLabel.TabIndex = 8;
            EmailLabel.Text = "Email : ";
            // 
            // DOBLabel
            // 
            DOBLabel.AutoSize = true;
            DOBLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DOBLabel.Location = new Point(50, 142);
            DOBLabel.Name = "DOBLabel";
            DOBLabel.Size = new Size(104, 21);
            DOBLabel.TabIndex = 9;
            DOBLabel.Text = "Date of Birth :";
            // 
            // PMBLabel
            // 
            PMBLabel.AutoSize = true;
            PMBLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PMBLabel.Location = new Point(431, 182);
            PMBLabel.Name = "PMBLabel";
            PMBLabel.Size = new Size(144, 21);
            PMBLabel.TabIndex = 10;
            PMBLabel.Text = "Branch to Register :";
            // 
            // PasswordLable
            // 
            PasswordLable.AutoSize = true;
            PasswordLable.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordLable.Location = new Point(71, 232);
            PasswordLable.Name = "PasswordLable";
            PasswordLable.Size = new Size(83, 21);
            PasswordLable.TabIndex = 11;
            PasswordLable.Text = "Password :";
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(355, 334);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(75, 23);
            SubmitButton.TabIndex = 12;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // MonthTextBox
            // 
            MonthTextBox.Location = new Point(231, 142);
            MonthTextBox.Name = "MonthTextBox";
            MonthTextBox.PlaceholderText = "MM";
            MonthTextBox.Size = new Size(56, 23);
            MonthTextBox.TabIndex = 13;
            MonthTextBox.Validating += MonthTextBox_Validating;
            // 
            // YearTextBox
            // 
            YearTextBox.Location = new Point(306, 142);
            YearTextBox.Name = "YearTextBox";
            YearTextBox.PlaceholderText = "YYYY";
            YearTextBox.Size = new Size(56, 23);
            YearTextBox.TabIndex = 14;
            YearTextBox.Validating += YearTextBox_Validating;
            // 
            // BackToLoginButton
            // 
            BackToLoginButton.ForeColor = Color.Black;
            BackToLoginButton.Location = new Point(29, 25);
            BackToLoginButton.Name = "BackToLoginButton";
            BackToLoginButton.Size = new Size(75, 23);
            BackToLoginButton.TabIndex = 15;
            BackToLoginButton.Text = "Back";
            BackToLoginButton.UseVisualStyleBackColor = true;
            BackToLoginButton.Click += BackToLoginButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // ListOfBranch
            // 
            ListOfBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            ListOfBranch.FormattingEnabled = true;
            ListOfBranch.Items.AddRange(new object[] { "HereOne", "HereTwo" });
            ListOfBranch.Location = new Point(598, 182);
            ListOfBranch.Name = "ListOfBranch";
            ListOfBranch.Size = new Size(121, 23);
            ListOfBranch.TabIndex = 16;
            ListOfBranch.SelectedIndexChanged += ListOfBranch_SelectedIndexChanged;
            ListOfBranch.Validating += ListOfBranch_Validating;
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ListOfBranch);
            Controls.Add(BackToLoginButton);
            Controls.Add(YearTextBox);
            Controls.Add(MonthTextBox);
            Controls.Add(SubmitButton);
            Controls.Add(PasswordLable);
            Controls.Add(PMBLabel);
            Controls.Add(DOBLabel);
            Controls.Add(EmailLabel);
            Controls.Add(AddressLable);
            Controls.Add(NameLabel);
            Controls.Add(PasswordTextBox);
            Controls.Add(AddressTextBox);
            Controls.Add(EmailTextBox);
            Controls.Add(DateTextBox);
            Controls.Add(NameTextBox);
            Location = new Point(340, 344);
            Name = "SignUpForm";
            Text = "SignUpForm";
            Load += SignUpForm_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameTextBox;
        private TextBox DateTextBox;
        private TextBox EmailTextBox;
        private TextBox PasswordTextBox;
        private TextBox AddressTextBox;
        private Label PasswordLable;
        private Label PMBLabel;
        private Label DOBLabel;
        private Label EmailLabel;
        private Label AddressLable;
        private Label NameLabel;
        private Button SubmitButton;
        private TextBox YearTextBox;
        private TextBox MonthTextBox;
        private Button BackToLoginButton;
        private ErrorProvider errorProvider;
        private ComboBox ListOfBranch;
    }
}