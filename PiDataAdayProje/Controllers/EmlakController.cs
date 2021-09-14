using Microsoft.AspNetCore.Mvc;
using PiDataAdayProje.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Controllers
{
    public class EmlakController : Controller
    {
        private readonly IEmlakRepository _emlakRepository;
        public IActionResult Index()
        {
            return View();
        }
    }
}
