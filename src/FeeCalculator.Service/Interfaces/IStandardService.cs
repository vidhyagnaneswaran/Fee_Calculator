using FeeCalculator.Model;

namespace FeeCalculator.Service.Interfaces
{
    public interface IStandardService: IDomainService<Standard>, IRateService<Standard>
    {
    }
}
