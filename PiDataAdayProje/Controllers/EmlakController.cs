using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Controllers
{
    public class EmlakController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
