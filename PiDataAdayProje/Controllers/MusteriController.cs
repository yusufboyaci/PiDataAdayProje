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
    public class MusteriController : Controller
    {
        private readonly IMusteriRepository _musteriRepository;
        private readonly IIsyeriRepository _isyeriRepository;
        private readonly INotyfService _notfy;
        public MusteriController(IMusteriRepository musteriRepository, INotyfService notyf, IIsyeriRepository isyeriRepository)
        {
            _musteriRepository = musteriRepository;
            _isyeriRepository = isyeriRepository;
            _notfy = notyf;
        }
        public IActionResult Index()
        {            
            return View(_musteriRepository.Musteriler);
        }

        [HttpGet]
        public IActionResult Ekle() => View();
        [HttpPost]
        public IActionResult Ekle(Musteri musteri)
        {
            if (_isyeriRepository.Isyeriler.ToList() == null)
            {
                _notfy.Warning("Kayıtlı işyeri bulunmadığı için Müşteri listesine ulaşamazsınız!");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                musteri.IsyeriId = _isyeriRepository.GetById();//Buraya bak
                _musteriRepository.MusteriEkle(musteri);
                _notfy.Success("Müşteri Eklenmiştir.");
                return RedirectToAction("Index", "Musteri");
            }
            
        }
        [HttpGet]
        public IActionResult Guncelle(Guid id) => View(_musteriRepository.GetById(id));
        [HttpPost]
        public IActionResult Guncelle(Musteri musteri)
        {
            _musteriRepository.MusteriGuncelle(musteri);
            _notfy.Success("Müşteri Güncellenmiştir.");
            return RedirectToAction("Index", "Musteri");
        }
        public IActionResult Sil(Guid id)
        {
            _musteriRepository.MusteriSil(id);
            _notfy.Success("Müşteri Silinmiştir.");
            return RedirectToAction("Index", "Musteri");
        }
    }
}
