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
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // TextBoxEmail
            // 
            TextBoxEmail.Location = new Point(275, 158);
            TextBoxEmail.Name = "TextBoxEmail";
            TextBoxEmail.Size = new Size(216, 23);
            TextBoxEmail.TabIndex = 0;
            // 
            // TextBoxPW
            // 
            TextBoxPW.BackColor = SystemColors.ScrollBar;
            TextBoxPW.BorderStyle = BorderStyle.FixedSingle;
            TextBoxPW.Location = new Point(275, 219);
            TextBoxPW.Name = "TextBoxPW";
            TextBoxPW.PasswordChar = '*';
            TextBoxPW.Size = new Size(216, 23);
            TextBoxPW.TabIndex = 3;
            // 
            // LoginSubmitButton
            // 
            LoginSubmitButton.Location = new Point(340, 289);
            LoginSubmitButton.Name = "LoginSubmitButton";
            LoginSubmitButton.Size = new Size(75, 23);
            LoginSubmitButton.TabIndex = 2;
            LoginSubmitButton.Text = "Submit";
            LoginSubmitButton.UseVisualStyleBackColor = true;
            LoginSubmitButton.Click += LoginSubmitButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(257, 91);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(453, 91);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LoginSubmitButton);
            Controls.Add(TextBoxPW);
            Controls.Add(TextBoxEmail);
            Name = "LoginForm";
            RightToLeftLayout = true;
            Text = "Please Login";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBoxEmail;
        private TextBox TextBoxPW;
        private Button LoginSubmitButton;
        private Label label1;
        private Label label2;
    }
}