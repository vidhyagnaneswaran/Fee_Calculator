
using System.Threading.Tasks;
using FeeCalculator.CrossCutting.DTOs;

namespace FeeCalculator.Service.Interfaces
{
    public interface ICalculatorService
    {
        Task<ParkingRateDto> Calculate(TimerDto input);
    }
}
