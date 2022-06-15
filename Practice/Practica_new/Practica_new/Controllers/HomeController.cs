using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practica_new.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
namespace Practica_new.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       private readonly databaseconfigContext db = new databaseconfigContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       
        
        public IActionResult Index()
        { 
            
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
