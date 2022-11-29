using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeeApp.CustomValidation
{
    public class EmployeePhoneNumberValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                ErrorMessage = "Phone number is required";
                return false;
            }

            string number = Convert.ToString(value);
            string pattern = @"0(55|93|99)[0-9]{6}";

            Regex reg = new Regex(pattern);

            if (!reg.IsMatch(number))
            {
                ErrorMessage = "Please enter valid phone number";
                return false;
            }

            return true;
        }
    }
}
