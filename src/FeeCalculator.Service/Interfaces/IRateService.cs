using FeeCalculator.CrossCutting.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeeCalculator.Service.Interfaces
{
    public interface IRateService<T>
    {
        ParkingRateDto Calculate(IEnumerable<T> rates, DateTime start, DateTime end);
    }
}
