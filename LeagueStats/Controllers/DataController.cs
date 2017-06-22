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
            return "RGAPI-62f8af2b-ced7-449e-99a2-e653783e50d5";
        }

    }
}