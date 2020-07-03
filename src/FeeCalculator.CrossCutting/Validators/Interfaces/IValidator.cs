using System;
using System.Collections.Generic;
using System.Text;

namespace FeeCalculator.CrossCutting.Interfaces
{
    public interface IValidator<in T>
    {
        Validation IsValid(T input);
    }
}
