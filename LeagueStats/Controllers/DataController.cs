using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LeagueStats.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Key()
        {
            return "RGAPI-2fd3612a-a978-4aa8-a0ad-b3c18c135e6a";
        }

    }
}