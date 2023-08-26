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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            DateTime DOB = DateTime.Parse($"{YearTextBox.Text}-{MonthTextBox.Text}-{DateTextBox.Text} TimeSpan.Zero");


        }

        private void BackToLoginButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
