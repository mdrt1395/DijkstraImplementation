using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DijkstraImplementation.Utility
{
    public class PasswordSecurityAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not string password)
                return new ValidationResult("Invalid password format.");
            var regex = new Regex(@"(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()-_+=])");

            if (!regex.IsMatch(password))
            {
                return new ValidationResult($"{validationContext.DisplayName} must contain at least one uppercase letter, one number, and one special character.");
            }

            return ValidationResult.Success!;
        }

    }
}
