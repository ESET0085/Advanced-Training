using System;
using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Model.Validators
{
    public class NameCapitalCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var name = value as string;

            if (string.IsNullOrWhiteSpace(name))
            {
                return new ValidationResult("Please enter a name.");
            }

            // Check if the first character is uppercase
            if (!char.IsUpper(name[0]))
            {
                return new ValidationResult("Name must start with a capital letter.");
            }

            return ValidationResult.Success!;
        }
    }
}