using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeApp.CustomValidation
{
    public class EmployeeDateOfBirthValidationAttribute : ValidationAttribute
    {
        DateTime date;

        public override bool IsValid(object? value)
        { 
            if (value == null) return true;

            if (DateTime.TryParse((string?)value, out date))
            {
                var age = DateTime.Today.Year - date.Year;

                if (age >= 18) return true;

                ErrorMessage = "Employee age must be greater than 18";
                return false;
            }

            ErrorMessage = "Please Enter a valid date time format";
            return false;
        }
    }
}
