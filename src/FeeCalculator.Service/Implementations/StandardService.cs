using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeeCalculator.CrossCutting.DTOs;
using FeeCalculator.Data;
using FeeCalculator.Data.Interfaces;
using FeeCalculator.Model;
using FeeCalculator.Service.Interfaces;

namespace FeeCalculator.Service.Implementations
{
    public class StandardService : IStandardService
    {
        private readonly IRepository<Standard> _standardRepository;

        public StandardService(IStandardRepository standardRepository)
        {
            _standardRepository = standardRepository;
        }

        public async Task<IEnumerable<Standard>> GetAllAsync()
        {
            return await _standardRepository.SelectAllAsync();
        }

       
        public ParkingRateDto Calculate(IEnumerable<Standard> standardRates, DateTime start, DateTime end)
        {
            var result = new ParkingRateDto() { Name = CONSTANTS.RATE.STANDARD };

            var resultStandardMacro = 0.0;
            var resultStandardMicro = 0.0;
            var isStandard = false;
            var duration = (end - start).TotalHours;
            var maxStandardRate = standardRates.OrderBy(nr => nr.MaxHours).LastOrDefault();

            // More than max duration
            if (duration >= maxStandardRate.MaxHours)
            {
                resultStandardMacro = Math.Floor(duration / maxStandardRate.MaxHours) * maxStandardRate.Rate;
                duration = duration % maxStandardRate.MaxHours;
            }
            if (duration > 0)
            {
                foreach (var standardRate in standardRates)
                {
                    if (!isStandard && duration <= standardRate.MaxHours)
                    {
                        isStandard = true;
                        resultStandardMicro = standardRate.Rate;
                    }
                }
            }

            result.Price = resultStandardMacro + resultStandardMicro;

            return result;
        }

    }
}
