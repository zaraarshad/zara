using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using zara_099_web.Data;
using zara_099_web.Models;

namespace zara_099_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private dbcontext _dbContext;
        public HomeController(ILogger<HomeController> logger, dbcontext dbcontext)
        {
            _dbContext = dbcontext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<MImages> img = new List<MImages>
       
            {
                new MImages{ImageUrl="/Images/house5.jpg" ,label="Summer House"},
                new MImages{ImageUrl="/Images/house4.jpg" ,label="Brick House"},
                new MImages{ImageUrl="/Images/house3.jpg" ,label="Barn House"},

            };
            return View(img);
        }

        public IActionResult Contctus()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactPost(Contact_us cont)
        {
            try
            {
                _dbContext.Contacts.Add(cont);
                _dbContext.SaveChanges();
                ViewBag.sucess = "(Message send Successfully";
            }
            catch(Exception ex)
            {
                ViewBag.err = "Error";
            }
            return View("Contctus");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
