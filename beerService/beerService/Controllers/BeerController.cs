using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace beerService.Controllers
{
    [ApiController]
    [Route("")]
    public class BeerController : ControllerBase
    {

        private readonly ILogger<BeerController> _logger;

        public BeerController(ILogger<BeerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string[] Get()
        {
            Console.WriteLine("Inside Get()");

            if (String.IsNullOrEmpty(Beer.pour))
            {
                Console.WriteLine("Inside Get Initial Pour");
                Beer.pour = "True";
            }


            if (String.IsNullOrEmpty(Beer.ounces))
            {
                Console.WriteLine("Inside Get Initial Ounces");
                Beer.ounces = "12";
            }

            string[] result = { Beer.pour, Beer.ounces };

            Console.WriteLine("Beer.Pour: " + Beer.pour);
            Console.WriteLine("Beer.Ounces: " + Beer.ounces);
            return result;
        }

        [HttpPost]
        public void Set([FromForm] String newPour, [FromForm] String newOunces)
        {
            Console.WriteLine("Inside Set()");
            Console.WriteLine("newPour: " + newPour);
            Console.WriteLine("newOunces: " + newOunces);
            Beer.pour = newPour;
            Beer.ounces = newOunces;

        }
    }
}
