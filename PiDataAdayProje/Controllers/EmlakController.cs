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
    public class EmlakController : Controller
    {
        private readonly IEmlakRepository _emlakRepository;
        private readonly IIsyeriRepository _isyeriRepository;
        private readonly INotyfService _notfy;
        public EmlakController(IEmlakRepository emlakRepository, IIsyeriRepository isyeriRepository, INotyfService notyf)
        {
            _emlakRepository = emlakRepository;
            _isyeriRepository = isyeriRepository;
            _notfy = notyf;
        }
        public IActionResult Index()
        {
            return View(_emlakRepository.Emlaklar);
        }
        [HttpGet]
        public IActionResult Ekle() => View();
        [HttpPost]
        public IActionResult Ekle(Emlak emlak)
        {
            if (_isyeriRepository.Isyeriler.FirstOrDefault() == null)
            {
                _notfy.Error("Kayıtlı işyeri bulunmadığı için Emlak Listesine ekleyemezsiniz!");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                emlak.IsyeriId = _isyeriRepository.Isyeriler.FirstOrDefault().Id;
                _emlakRepository.EmlakEkle(emlak);
                _notfy.Success("Emlak eklenmiştir.");
                return RedirectToAction("Index", "Emlak");
            }
        }
        [HttpGet]
        public IActionResult Guncelle(Guid id) => View(_emlakRepository.GetById(id));
        [HttpPost]
        public IActionResult Guncelle(Emlak emlak)
        {
            if (_isyeriRepository.Isyeriler.FirstOrDefault() == null)
            {
                _notfy.Error("Kayıtlı işyeri bulunmadığı için Emlak Listesine güncelleyemezsiniz!");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                emlak.IsyeriId = _isyeriRepository.Isyeriler.FirstOrDefault().Id;
                _emlakRepository.EmlakGuncelle(emlak);
                _notfy.Success("Emlak Güncellenmiştir.");
                return RedirectToAction("Index", "Emlak");
            }
        }
        public IActionResult Sil(Guid id)
        {
            _emlakRepository.EmlakSil(id);
            _notfy.Success("Emlak Silinmiştir.");
            return RedirectToAction("Index", "Emlak");
        }
    }
}
