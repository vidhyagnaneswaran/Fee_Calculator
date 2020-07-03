using Autofac;
using Autofac.Core;
using FeeCalculator.CrossCutting.DTOs;
using FeeCalculator.CrossCutting.Interfaces;
using FeeCalculator.CrossCutting.Validators.Implementations;
using FeeCalculator.Data;
using FeeCalculator.Data.Implementations;
using FeeCalculator.Data.Interfaces;
using FeeCalculator.Model;
using FeeCalculator.Service;
using FeeCalculator.Service.Implementations;
using FeeCalculator.Service.Interfaces;

namespace FeeCalculator.API
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // Validators 
            builder.RegisterType<InputStringValidator>()
               .As<IValidator<string>>()
               .Keyed<IValidator<string>>(CONSTANTS.APPLICATION_TYPES.CONSOLE);

            builder.RegisterType<InputDateValidator>()
                .As<IValidator<string>>()
                .Keyed<IValidator<string>>(CONSTANTS.APPLICATION_TYPES.CONSOLE);

            builder.RegisterType<InputDatesValidator>()
                .As<IValidator<TimerDto>>();

            // Repositories 
            builder.RegisterType<SpecialJsonRepository>()
                .As<IRepository<Special>>()
                .As<ISpecialRepository>()
                .SingleInstance();

            builder.RegisterType<CalculatorService>()
             .As<ICalculatorService>()
             .SingleInstance();

            builder.RegisterType<SpecialService>()
                .As<IDomainService<Special>>()
                .As<ISpecialService>()
                .SingleInstance();

            builder.RegisterType<StandardService>()
                .As<IDomainService<Standard>>()
                .As<IStandardService>()
                .SingleInstance();

            builder.RegisterType<StandardJsonRepository>()
                .As<IRepository<Standard>>()
                .As<IStandardRepository>()
                .SingleInstance();

            builder.RegisterType<ApplicationService>()
               .As<IApplicationService>()
               .WithParameter(
                   new ResolvedParameter(
                       (pi, ctx) => pi.ParameterType == typeof(IValidator<string>),
                       (pi, ctx) => ctx.ResolveKeyed<IValidator<string>>(CONSTANTS.APPLICATION_TYPES.CONSOLE)))
               .SingleInstance();         

        }
    }
}
