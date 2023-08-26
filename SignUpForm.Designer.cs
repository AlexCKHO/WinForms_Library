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
            NameTextBox = new TextBox();
            DateTextBox = new TextBox();
            EmailTextBox = new TextBox();
            PMBTextBox = new TextBox();
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
            SuspendLayout();
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(307, 80);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(208, 23);
            NameTextBox.TabIndex = 0;
            // 
            // DateTextBox
            // 
            DateTextBox.Location = new Point(307, 125);
            DateTextBox.Name = "DateTextBox";
            DateTextBox.Size = new Size(56, 23);
            DateTextBox.TabIndex = 1;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(307, 169);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(208, 23);
            EmailTextBox.TabIndex = 2;
            // 
            // PMBTextBox
            // 
            PMBTextBox.Location = new Point(307, 303);
            PMBTextBox.Name = "PMBTextBox";
            PMBTextBox.Size = new Size(208, 23);
            PMBTextBox.TabIndex = 5;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(307, 259);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(208, 23);
            PasswordTextBox.TabIndex = 4;
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(307, 214);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(208, 23);
            AddressTextBox.TabIndex = 3;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NameLabel.Location = new Point(248, 80);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(59, 21);
            NameLabel.TabIndex = 6;
            NameLabel.Text = "Name :";
            // 
            // AddressLable
            // 
            AddressLable.AutoSize = true;
            AddressLable.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddressLable.Location = new Point(234, 214);
            AddressLable.Name = "AddressLable";
            AddressLable.Size = new Size(73, 21);
            AddressLable.TabIndex = 7;
            AddressLable.Text = "Address :";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EmailLabel.Location = new Point(248, 169);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(59, 21);
            EmailLabel.TabIndex = 8;
            EmailLabel.Text = "Email : ";
            // 
            // DOBLabel
            // 
            DOBLabel.AutoSize = true;
            DOBLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DOBLabel.Location = new Point(203, 125);
            DOBLabel.Name = "DOBLabel";
            DOBLabel.Size = new Size(104, 21);
            DOBLabel.TabIndex = 9;
            DOBLabel.Text = "Date of Birth :";
            // 
            // PMBLabel
            // 
            PMBLabel.AutoSize = true;
            PMBLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PMBLabel.Location = new Point(83, 301);
            PMBLabel.Name = "PMBLabel";
            PMBLabel.Size = new Size(224, 21);
            PMBLabel.TabIndex = 10;
            PMBLabel.Text = "Primary Memebership Branch :";
            // 
            // PasswordLable
            // 
            PasswordLable.AutoSize = true;
            PasswordLable.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordLable.Location = new Point(224, 259);
            PasswordLable.Name = "PasswordLable";
            PasswordLable.Size = new Size(83, 21);
            PasswordLable.TabIndex = 11;
            PasswordLable.Text = "Password :";
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(374, 359);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(75, 23);
            SubmitButton.TabIndex = 12;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // MonthTextBox
            // 
            MonthTextBox.Location = new Point(384, 125);
            MonthTextBox.Name = "MonthTextBox";
            MonthTextBox.Size = new Size(56, 23);
            MonthTextBox.TabIndex = 13;
            // 
            // YearTextBox
            // 
            YearTextBox.Location = new Point(459, 125);
            YearTextBox.Name = "YearTextBox";
            YearTextBox.Size = new Size(56, 23);
            YearTextBox.TabIndex = 14;
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
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Controls.Add(PMBTextBox);
            Controls.Add(PasswordTextBox);
            Controls.Add(AddressTextBox);
            Controls.Add(EmailTextBox);
            Controls.Add(DateTextBox);
            Controls.Add(NameTextBox);
            Location = new Point(340, 344);
            Name = "SignUpForm";
            Text = "SignUpForm";
            Load += SignUpForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameTextBox;
        private TextBox DateTextBox;
        private TextBox EmailTextBox;
        private TextBox PMBTextBox;
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
    }
}