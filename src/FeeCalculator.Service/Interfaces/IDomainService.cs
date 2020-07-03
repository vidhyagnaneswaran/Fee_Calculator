using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeeCalculator.Service.Interfaces
{
    public interface IDomainService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
