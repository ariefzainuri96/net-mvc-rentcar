using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentCar.Data;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RentalCarDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, RentalCarDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
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

        public IActionResult Index(string? brand, string? availability)
        {
            var query = _dbContext.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(brand))
            {
                query = query.Where(data => data.Brand.ToLower().Contains(brand));
            }

            if (string.IsNullOrEmpty(availability))
            {
                return View(query.Where(data => data.Status.ToLower().Equals("tersedia")).ToList());
            }

            // filter out when availability search param is not null

            // we add 1 because, we want to make sure that the car is available to use
            // by preventing using the car with exact date time of end date
            var availabilityDateTime = DateTime
                .ParseExact(availability, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
                .AddDays(1);

            var rentQuery = _dbContext.Rents.AsQueryable();

            var rentedAvailableIds = rentQuery
                .Where(data => data.Status.Equals("Active") && availabilityDateTime > data.EndDate)
                .Select(data => data.CarId).ToList();

            query =
                query.Where(data => rentedAvailableIds.Contains(data.Id) || data.Status.ToLower().Equals("tersedia"));

            return View(query.ToList());
        }
    }
}
