using FeeCalculator.CrossCutting.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeeCalculator.CrossCutting.Validators.Implementations
{
    public class InputStringValidator : IValidator<string>
    {
        public Validation IsValid(string input)
        {
            var result = new Validation() { IsValid = true };

            if (string.IsNullOrEmpty(input))
            {
                result.IsValid = false;
                result.ErrorMessage = "Please enter a value";
            }

            return result;
        }
    }
}
