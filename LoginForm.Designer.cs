namespace EI_Task
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        ///



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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TextBoxEmail = new TextBox();
            TextBoxPW = new TextBox();
            LoginSubmitButton = new Button();
            SignUpFormButton = new Button();
            UserNameLabel = new Label();
            PasswordLabel = new Label();
            LoginStatusLabel = new Label();
            SuspendLayout();
            // 
            // TextBoxEmail
            // 
            TextBoxEmail.Location = new Point(296, 239);
            TextBoxEmail.Name = "TextBoxEmail";
            TextBoxEmail.Size = new Size(216, 23);
            TextBoxEmail.TabIndex = 0;
            // 
            // TextBoxPW
            // 
            TextBoxPW.BackColor = SystemColors.ScrollBar;
            TextBoxPW.BorderStyle = BorderStyle.FixedSingle;
            TextBoxPW.Location = new Point(296, 300);
            TextBoxPW.Name = "TextBoxPW";
            TextBoxPW.PasswordChar = '*';
            TextBoxPW.Size = new Size(216, 23);
            TextBoxPW.TabIndex = 3;
            TextBoxPW.KeyPress += TextBoxPW_KeyPress;
            // 
            // LoginSubmitButton
            // 
            LoginSubmitButton.Location = new Point(296, 373);
            LoginSubmitButton.Name = "LoginSubmitButton";
            LoginSubmitButton.Size = new Size(216, 23);
            LoginSubmitButton.TabIndex = 2;
            LoginSubmitButton.Text = "Submit";
            LoginSubmitButton.UseVisualStyleBackColor = true;
            LoginSubmitButton.Click += LoginSubmitButton_Click;
            // 
            // SignUpFormButton
            // 
            SignUpFormButton.Location = new Point(296, 428);
            SignUpFormButton.Name = "SignUpFormButton";
            SignUpFormButton.Size = new Size(216, 23);
            SignUpFormButton.TabIndex = 6;
            SignUpFormButton.Text = "Sign Up";
            SignUpFormButton.UseVisualStyleBackColor = true;
            SignUpFormButton.Click += SignUpFormButton_Click;
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            UserNameLabel.Location = new Point(173, 237);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(117, 25);
            UserNameLabel.TabIndex = 7;
            UserNameLabel.Text = "User Name :";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            PasswordLabel.Location = new Point(189, 298);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(101, 25);
            PasswordLabel.TabIndex = 8;
            PasswordLabel.Text = "Password :";
            // 
            // LoginStatusLabel
            // 
            LoginStatusLabel.AutoSize = true;
            LoginStatusLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            LoginStatusLabel.Location = new Point(296, 190);
            LoginStatusLabel.Name = "LoginStatusLabel";
            LoginStatusLabel.Size = new Size(0, 32);
            LoginStatusLabel.TabIndex = 9;
            LoginStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(793, 686);
            Controls.Add(LoginStatusLabel);
            Controls.Add(PasswordLabel);
            Controls.Add(UserNameLabel);
            Controls.Add(SignUpFormButton);
            Controls.Add(LoginSubmitButton);
            Controls.Add(TextBoxPW);
            Controls.Add(TextBoxEmail);
            Name = "LoginForm";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Please Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBoxEmail;
        private TextBox TextBoxPW;
        private Button LoginSubmitButton;
        private Button SignUpFormButton;
        private Label UserNameLabel;
        private Label PasswordLabel;
        private Label LoginStatusLabel;
    }
}