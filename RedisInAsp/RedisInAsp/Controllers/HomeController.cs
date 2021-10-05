using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedisInAsp.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RedisInAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDatabase _db;

        public HomeController(ILogger<HomeController> logger, IConnectionMultiplexer redis)
        {
            _logger = logger;
            this._db = redis.GetDatabase();
        }

        public IActionResult Index()
        {
            //return View();
            _db.StringSet("fullName", "bleso");
            var name = _db.StringGet("fullName");
            return View("Index", name);
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
