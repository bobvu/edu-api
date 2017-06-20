using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MW.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            //ViewData["Message"] = "This API is built by Hung Vu to practice latest technologies of Web, Mobile, Front-End and Back-End Developement.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Hung's Contact.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
