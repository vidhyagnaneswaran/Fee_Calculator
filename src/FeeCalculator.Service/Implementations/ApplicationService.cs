using FeeCalculator.CrossCutting;
using FeeCalculator.CrossCutting.DTOs;
using FeeCalculator.CrossCutting.Interfaces;
using FeeCalculator.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeeCalculator.Service.Implementations
{
    public class ApplicationService : IApplicationService
    {
        private readonly ICalculatorService _calculatorService;
        private readonly IEnumerable<IValidator<string>> _inputValidators;
        private readonly IEnumerable<IValidator<TimerDto>> _datesValidators;

        public ApplicationService(ICalculatorService calculatorService, IEnumerable<IValidator<string>> inputValidators, IEnumerable<IValidator<TimerDto>> datesValidators)
        {
            _calculatorService = calculatorService;
            _inputValidators = inputValidators;
            _datesValidators = datesValidators;
        }

        public async Task<string> ProcessAsync(TimerDto input)
        {
            var response = await _calculatorService.Calculate(input);
            var result =
                "\nPackage : " + response.Name +
                "\nTOTAL COST : " + response.Price.ToString("C");

            return result;
        }

        
        public Validation ValidateInput(IList<string> input, out TimerDto timer)
        {
            timer = new TimerDto();

            foreach (var validator in _inputValidators)
            {
                foreach (var i in input)
                {
                    var r = validator.IsValid(i);
                    if (!r.IsValid)
                    {
                        return r;
                    }
                }
            }

            // Add them into the out objects
            timer.Entry = Convert.ToDateTime(input.ElementAt(0));
            timer.Exit = Convert.ToDateTime(input.ElementAt(1));

            foreach (var validator in _datesValidators)
            {
                var r = validator.IsValid(timer);
                if (!r.IsValid)
                {
                    return r;
                }
            }

            return new Validation() { IsValid = true };
        }
    }
}
