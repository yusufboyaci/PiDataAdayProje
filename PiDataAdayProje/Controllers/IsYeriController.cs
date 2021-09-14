using AspNetCoreHero.ToastNotification.Abstractions;
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
        private readonly INotyfService _notfy;
        public IsYeriController(IIsyeriRepository isyeriRepository, INotyfService notyf)
        {
            _isyeriRepository = isyeriRepository;
            _notfy = notyf;
        }
        public IActionResult Index() => View(_isyeriRepository.Isyeriler);

        [HttpGet]
        public IActionResult Ekle() => View();
       [HttpPost]
       public IActionResult Ekle(Isyeri isyeri)
        {
            _isyeriRepository.IsyeriEkle(isyeri);           
            _notfy.Success("İş Yeri Eklenmiştir.");
            return RedirectToAction("Index","IsYeri");
        }
        [HttpGet]
        public IActionResult Guncelle(Guid id) => View(_isyeriRepository.GetById(id));
        [HttpPost]
        public IActionResult Guncelle(Isyeri isyeri)
        {
            _isyeriRepository.IsyeriGuncelle(isyeri);
            _notfy.Success("İş Yeri Güncellenmiştir.");
            return RedirectToAction("Index", "IsYeri");
        }
        public IActionResult Sil(Guid id)
        {
            _isyeriRepository.IsyeriSil(id);
            _notfy.Success("İş Yeri Silinmiştir.");
            return RedirectToAction("Index", "Isyeri");
        }
    }
}
