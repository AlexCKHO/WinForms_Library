using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Services
{
    public interface IValidationService
    {
        bool ValidatePublishedYear(object input);
        bool ValidateCellValue(string columnName, object value);
        bool ValidatingPasswordInput(string input);
        bool ValidatingEmailInput(string input);
        bool IsValidDate(int day, int month, int year);
        bool MainFormAreAllInputsValid(Control.ControlCollection controls, ErrorProvider errorProvider);
        bool SignUpFormAreAllInputsValid(Control.ControlCollection controls, ErrorProvider errorProvider);
    }
}
