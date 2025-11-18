using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RentCar.Data;
using RentCar.Extensions;
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

        public IActionResult Index()
        {
            return View();
        }
    
        public async Task<IActionResult> GetCar(int page, string? brand, string? availability)
        {            
            var query = _dbContext.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(brand))
            {
                query = query.Where(data => data.Brand.ToLower().Contains(brand));
            }

            if (string.IsNullOrEmpty(availability))
            {
                query = query.Where(data => data.Status.ToLower().Equals("tersedia"));

                return PartialView("_CarList", await query.ToPagedResultAsync(page, 10));
            }

            // filter out when availability search param is not null

            // we add 1 because, we want to make sure that the car is available to use
            // by preventing using the car with exact date time of end date
            var availabilityDateTime = DateTime
                .ParseExact(availability, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
                .AddDays(1);

            var rentQuery = _dbContext.Rents.AsQueryable();

            var rentedAvailableIds = await rentQuery
                .Where(data => data.Status.Equals("Active") && availabilityDateTime > data.EndDate)
                .Select(data => data.CarId)
                .ToListAsync();

            // filter using IN CarId || Status == tersedia
            query =
                query
                    .Where(data => rentedAvailableIds.Contains(data.Id) || data.Status.ToLower().Equals("tersedia"));        

            return PartialView("_CarList", await query.ToPagedResultAsync(page, 10));
        }

    }
}
