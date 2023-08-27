using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EI_Task.Services
{
    public  class Validation
    {
        public IEnumerable<Control> Controls { get; private set; }

        public static bool ValidatePublishedYear(object input)
        {
            int year = Convert.ToInt32(input);

            int currentYear = DateTime.Now.Year;
            if (year >= 1 && year <= currentYear && year != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AreAllInputsValid(Control.ControlCollection controls, ErrorProvider errorProvider)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox || control is ComboBox && control.Name != "ListOfBranch")
                {
                    if (String.IsNullOrEmpty(control.Text))
                    {
                        return false;
                    }

                    string errorMessage = errorProvider.GetError(control);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
