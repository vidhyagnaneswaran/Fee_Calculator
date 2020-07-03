using System.Threading.Tasks;
using FeeCalculator.CrossCutting.DTOs;
using FeeCalculator.Service.Interfaces;

namespace FeeCalculator.Service.Implementations
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ISpecialService _specialService;
        private readonly IStandardService _standardService;

        public CalculatorService(ISpecialService specialService, IStandardService standardService)
        {
            _specialService = specialService;
            _standardService = standardService;
        }

        public async Task<ParkingRateDto> Calculate(TimerDto input)
        {
            var specialRates = await _specialService.GetAllAsync();
            var standardRates = await _standardService.GetAllAsync();

            var result = new ParkingRateDto();

            var resultSpecial = _specialService.Calculate(specialRates, input.Entry, input.Exit);
            result = resultSpecial;

            var resultStandard = _standardService.Calculate(standardRates, input.Entry, input.Exit);

            // select the lowest price
            if (resultStandard.Price > 0 && (result.Price == 0 || result.Price > resultStandard.Price))
            {
                result.Name = resultStandard.Name;
                result.Price = resultStandard.Price;
            }

            return result;
        }
    }
}
