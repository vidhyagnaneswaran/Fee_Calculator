using System.Collections.Generic;
using System.Threading.Tasks;
using FeeCalculator.CrossCutting;
using FeeCalculator.CrossCutting.DTOs;

namespace FeeCalculator.Service.Interfaces
{
    public interface IApplicationService
    {
        Validation ValidateInput(IList<string> input, out TimerDto timer);
        Task<string> ProcessAsync(TimerDto input);
    }
}
