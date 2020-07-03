using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeeCalculator.Data.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> SelectAllAsync();
    }
}
