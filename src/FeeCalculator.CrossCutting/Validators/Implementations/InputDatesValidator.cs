using FeeCalculator.CrossCutting.DTOs;
using FeeCalculator.CrossCutting.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeeCalculator.CrossCutting.Validators.Implementations
{
    public class InputDatesValidator : IValidator<TimerDto>
    {
        public Validation IsValid(TimerDto input)
        {
            var result = new Validation() { IsValid = true };

            var start = Convert.ToDateTime(input.Entry);
            var end = Convert.ToDateTime(input.Exit);

            if (end <= start)
            {
                result.IsValid = false;
                result.ErrorMessage = "End date and time must be greater than start date and time";
            }

            return result;
        }
    }
}
