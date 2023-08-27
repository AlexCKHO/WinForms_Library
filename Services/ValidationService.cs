using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EI_Task.Services
{
    public  class ValidationService : IValidationService
    {


        public bool ValidatePublishedYear(object input)
        {
            string inputString = input.ToString();

            if (int.TryParse(inputString, out int year))
            {
                int currentYear = DateTime.Now.Year;
                if (year >= 1 && year <= currentYear && year != null)
                {
                    return true;
                }

            }
            return false;

        }


        public bool ValidateCellValue(string columnName, object value)
        {
            if (columnName == "Name")
            {
                if (String.IsNullOrWhiteSpace(value.ToString()))
                {
                    return false;
                }
            }
            else if (columnName == "PublishedYear")
            {
                int newYear;
                if(int.TryParse(value.ToString(), out newYear))
                {
                    if (this.ValidatePublishedYear(newYear))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;  
        }

        public bool ValidatingPasswordInput(string input)
        {
            return Regex.IsMatch(input, @"^(?=.*[A-Za-z])(?=.*\d\d)(?=.*[@$!%*#?&.])[^ ]{7,}$");
        }

        public bool ValidatingEmailInput(string input)
        {
            string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
            return Regex.IsMatch(input, pattern);
        }

        public  bool MainFormAreAllInputsValid(Control.ControlCollection controls, ErrorProvider errorProvider)
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

        public bool SignUpFormAreAllInputsValid(Control.ControlCollection controls, ErrorProvider errorProvider)
        {
            foreach (Control control in controls)
            {
                if (control is System.Windows.Forms.TextBox || control is System.Windows.Forms.ComboBox)
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


        public bool IsValidDate(int day, int month, int year)
        {
            // Check if year, month and day form a valid date
            if (year < 1900 || year > DateTime.Now.Year)
            {
                return false;
            }

            if (month < 1 || month > 12)
            {
                return false;
            }

            int maxDay = DateTime.DaysInMonth(year, month);

            if (day < 1 || day > maxDay)
            {
                return false;
            }

            return true;
        }






    }
}
