
using System;
using System.Collections.Generic;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeeCalculator.API;
using FeeCalculator.CrossCutting.DTOs;
using FeeCalculator.Service.Interfaces;

namespace FeeCalculator.Test
{
    [TestClass]
    public class CalculatorServiceTest
    {
        private ICalculatorService _calculatorService;

        [TestInitialize]
        public void Init()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ServicesModule>();
            IContainer container = containerBuilder.Build();

            _calculatorService = container.Resolve<ICalculatorService>();
        }

        [TestMethod]
        public void EarlyEntry_EarlyExit_RateTest()
        {
            List<CalculatorCase> testCases = new List<CalculatorCase>()
            {
                new CalculatorCase()
                {
                    TimerData = new TimerDto() { Entry = new DateTime(2020, 7, 6, 6, 0, 0), Exit = new DateTime(2020, 7, 6, 15, 30, 0) },
                    ExpectedData = new ParkingRateDto() { Name = "Early Bird", Price = 13 }
                },

                new CalculatorCase()
                {
                    TimerData = new TimerDto() { Entry = new DateTime(2020, 7, 6, 9, 0, 0), Exit = new DateTime(2020, 7, 6, 23, 30, 0) },
                    ExpectedData = new ParkingRateDto() { Name = "Early Bird", Price = 13 }
                },
                 new CalculatorCase()
                {
                    TimerData = new TimerDto() { Entry = new DateTime(2020, 7, 6, 7, 0, 0), Exit = new DateTime(2020, 7, 6, 10, 30, 0) },
                    ExpectedData = new ParkingRateDto() { Name = "Early Bird", Price = 13 }
                }
            };

            foreach (var c in testCases)
            {
                var result = _calculatorService.Calculate(c.TimerData).Result;
                Assert.AreEqual(c.ExpectedData.Name, result.Name);
                Assert.AreEqual(c.ExpectedData.Price, result.Price);
            }
        }

        [TestMethod]
        public void LateEntry_ExitNightTest()
        {
            List<CalculatorCase> testCases = new List<CalculatorCase>()
            {
                new CalculatorCase()
                {
                    TimerData = new TimerDto() { Entry = new DateTime(2020, 7, 6, 18, 0, 0), Exit = new DateTime(2020, 7, 7, 6, 0, 0) },
                    ExpectedData = new ParkingRateDto() { Name = "Night Rate", Price = 6.5 }
                },

                new CalculatorCase()
                {
                    TimerData = new TimerDto() { Entry = new DateTime(2020, 7, 8, 0, 0, 0), Exit = new DateTime(2020, 7, 8, 6, 30, 0) },
                    ExpectedData = new ParkingRateDto() { Name = "Night Rate", Price = 6.5 }
                },
                 new CalculatorCase()
                {
                    TimerData = new TimerDto() { Entry = new DateTime(2020, 7, 8, 21, 0, 0), Exit = new DateTime(2020, 7, 9, 4, 0, 0) },
                    ExpectedData = new ParkingRateDto() { Name = "Night Rate", Price = 6.5 }
                }
            };

            foreach (var c in testCases)
            {
                var result = _calculatorService.Calculate(c.TimerData).Result;
                Assert.AreEqual(c.ExpectedData.Name, result.Name);
                Assert.AreEqual(c.ExpectedData.Price, result.Price);
            }
        }

        [TestMethod]
        public void Weekend_Enter_And_Exit()
        {
            List<CalculatorCase> testCases = new List<CalculatorCase>()
            {
                new CalculatorCase()
                {
                    TimerData = new TimerDto() { Entry = new DateTime(2020, 7, 4, 0, 0, 0), Exit = new DateTime(2020, 7, 6, 0, 0, 0) },
                    ExpectedData = new ParkingRateDto() { Name = "Weekend Rate", Price = 10 }
                },

                new CalculatorCase()
                {
                    TimerData = new TimerDto() { Entry = new DateTime(2020, 7, 4, 8, 0, 0), Exit = new DateTime(2020, 7, 5, 20, 30, 0) },
                    ExpectedData = new ParkingRateDto() { Name = "Weekend Rate", Price = 10 }
                },
                 new CalculatorCase()
                {
                    TimerData = new TimerDto() { Entry = new DateTime(2020, 7, 4, 9, 0, 0), Exit = new DateTime(2020, 7, 5, 0, 0, 0) },
                    ExpectedData = new ParkingRateDto() { Name = "Weekend Rate", Price = 10 }
                }
            };

            foreach (var c in testCases)
            {
                var result = _calculatorService.Calculate(c.TimerData).Result;
                Assert.AreEqual(c.ExpectedData.Name, result.Name);
                Assert.AreEqual(c.ExpectedData.Price, result.Price);
            }

        }

        [TestMethod]
        public void StandardConditionTest()
        {
            List<CalculatorCase> testCases = new List<CalculatorCase>()
            {
                new CalculatorCase()
                {
                    TimerData = new TimerDto() { Entry = new DateTime(2020, 7, 8, 9, 0, 0), Exit = new DateTime(2020, 7, 8, 10, 0, 0) },
                    ExpectedData = new ParkingRateDto() { Name = "Standard Rate", Price = 5 }
                },

                new CalculatorCase()
                {
                    TimerData = new TimerDto() { Entry = new DateTime(2020, 7, 8, 10, 0, 0), Exit = new DateTime(2020, 7, 8, 12, 30, 0) },
                    ExpectedData = new ParkingRateDto() { Name = "Standard Rate", Price = 10 }
                },
                 new CalculatorCase()
                {
                    TimerData = new TimerDto() { Entry = new DateTime(2020, 7, 8, 12, 0, 0), Exit = new DateTime(2020, 7, 8, 15, 0, 0) },
                    ExpectedData = new ParkingRateDto() { Name = "Standard Rate", Price = 15 }
                }
            };

            foreach (var c in testCases)
            {
                var result = _calculatorService.Calculate(c.TimerData).Result;
                Assert.AreEqual(c.ExpectedData.Name, result.Name);
                Assert.AreEqual(c.ExpectedData.Price, result.Price);
            }

        }

    }

    public class CalculatorCase
    {
        public TimerDto TimerData { get; set; }
        public ParkingRateDto ExpectedData { get; set; }
    }
}
