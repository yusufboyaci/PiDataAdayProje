using PiDataAdayProje.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Models.ViewModels
{
    public class CreateUserVm
    {
        [Display(Name ="Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        [Display(Name ="Şifre")]
        public string Sifre { get; set; }
        [Display(Name = "Mail Adresi")]
        public string Mail { get; set; }
        public static implicit operator AppUser(CreateUserVm createUserVm)
        {
            return new AppUser
            {
                Email = createUserVm.Mail,
                UserName = createUserVm.KullaniciAdi
            };
        }
    }
}
