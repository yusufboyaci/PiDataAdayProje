using Microsoft.AspNetCore.Mvc;
using PiDataAdayProje.Models.Entities;
using PiDataAdayProje.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Controllers
{
    //Projede Emlak işletmesini ifade eder.
    public class IsYeriController : Controller
    {
        private readonly IIsyeriRepository _isyeriRepository;
        public IsYeriController(IIsyeriRepository isyeriRepository)
        {
            _isyeriRepository = isyeriRepository;
        }
        public IActionResult Index() => View(_isyeriRepository.Isyeriler);

        [HttpGet]
        public IActionResult Ekle() => View();
       [HttpPost]
       public IActionResult Ekle(Isyeri isyeri)
        {
            _isyeriRepository.IsyeriEkle(isyeri);
            return RedirectToAction("Index","IsYeri");
        }
        [HttpGet]
        public IActionResult Guncelle(Guid id) => View(_isyeriRepository.GetById(id));
        [HttpPost]
        public IActionResult Guncelle(Isyeri isyeri)
        {
            _isyeriRepository.IsyeriGuncelle(isyeri);
            return RedirectToAction("Index", "IsYeri");
        }
        public IActionResult Sil(Guid id)
        {
            _isyeriRepository.IsyeriSil(id);
            return RedirectToAction("Index", "Isyeri");
        }
    }
}
