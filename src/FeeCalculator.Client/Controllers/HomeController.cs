using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FeeCalculator.Client.Models;
using FeeCalculator.Service.Interfaces;
using FeeCalculator.CrossCutting.DTOs;


namespace FeeCalculator.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationService _applicationService;

        public HomeController(ILogger<HomeController> logger, IApplicationService applicationService)
        {
            _logger = logger;
            _applicationService = applicationService;
        }

        public IActionResult Index(string dateFrom, string dateTo)
        {
            //var localDate = DateTime.UtcNow.ToLocalDateTime();
            //var todayStartDate = new DateTime(localDate.Year, localDate.Month, localDate.Day, 0, 0, 0);
            //var todayEndDate = new DateTime(localDate.Year, localDate.Month, localDate.Day, 23, 59, 59);


            //var startDate = string.IsNullOrEmpty(dateFrom) ? todayStartDate : Convert.ToDateTime(DateTime.ParseExact(
            //      dateFrom, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture));
            //var endDate = string.IsNullOrEmpty(dateTo) ? todayEndDate : Convert.ToDateTime(DateTime.ParseExact(
            //      dateTo, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)).AddDays(1);

            if (string.IsNullOrEmpty(dateFrom) || string.IsNullOrEmpty(dateTo))
            {
                return View();
            }

            var timer = new TimerDto();

            var input = new List<string>
            {
                dateFrom,
                dateTo
            };

            var valid = _applicationService.ValidateInput(input, out timer);

            if (!valid.IsValid)
            {
                _logger.LogError(valid.ErrorMessage);
                ViewData["message"] = valid.ErrorMessage;
                return View();
            }

            try
            {
                var response = _applicationService.ProcessAsync(timer).Result;
                ViewData["response"] = response;
            }
            catch (Exception ex)
            {
                ViewData["message"] = ex.Message;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
