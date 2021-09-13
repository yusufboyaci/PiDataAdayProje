using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PiDataAdayProje.Models.Entities;
using PiDataAdayProje.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Controllers
{
    public class UserController : Controller
    {
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login(string returnUrl)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string returnUrl, LoginVm loginVm)
        {
            AppUser user = await _userManager.FindByNameAsync(loginVm.KullaniciAdi);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVm.Sifre, true, true);
                if (result.Succeeded)
                {
                    return Redirect(returnUrl != null ? returnUrl : Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("Parola Hatalı", "Girdiğiniz parola yanlış, lütfen tekrar deneyiniz");
                }

            }
            else
            {
                ModelState.AddModelError("Kullanıcı Bulunamadı", "Girdiğiniz bilgilerle kullanıcı bulunamadı, lütfen tekrar deneyiniz");
            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserVm createUserVm)
        {
            AppUser user = createUserVm;
            IdentityResult result = await _userManager.CreateAsync(user, createUserVm.Sifre);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");

            }
            else
            {
                ModelState.AddModelError("Kullanıcı Kayıt Edilemedi", "Girdiğiniz bilgilerle kullanıcı kayıt edilemedi, lütfen tekrar deneyiniz");

            }

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
