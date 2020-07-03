using FeeCalculator.CrossCutting.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeeCalculator.CrossCutting.Validators.Implementations
{
    public class InputDateValidator : IValidator<string>
    {
        public Validation IsValid(string input)
        {
            var result = new Validation() { IsValid = true };

            try
            {
                if (Convert.ToDateTime(input) == default)
                {
                    result.IsValid = false;
                    result.ErrorMessage = "Date is not valid";
                }
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
