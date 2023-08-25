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
    public partial class Form2 : Form
    {
        int input;
        public Form2(int someData)
        {
            InitializeComponent();
             input = someData;
            changeTextTesting();
        }

        private void changeTextTesting()
        {
            label1.Text = $"Your user ID is {input}";
        }
        
    }
}
