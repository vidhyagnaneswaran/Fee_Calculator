using FeeCalculator.Model;
using FeeCalculator.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeeCalculator.Service.Interfaces
{
    public interface ISpecialService : IDomainService<Special>, IRateService<Special>
    {
    }
}
