using PiDataAdayProje.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Models.Entities
{
    public class Emlak
    {
        public Guid Id { get; set; }
        public Guid IsyeriId { get; set; }//FK
        public Guid MusteriId { get; set; }//FK
        [Display(Name = "Emlak Türü")]
        public string EmlakTuru { get; set; }        
        public ulong Metrekare { get; set; }
        [Display(Name ="Oda Sayısı")]
        public int OdaSayisi { get; set; }
        public int Kat { get; set; }
        [Display(Name = "Bina Katı")]
        public int BinaKati { get; set; }
        [Display(Name = "Isınma Türü")]
        public IsinmaTuru IsinmaTuru { get; set; }
    
        public virtual Isyeri Isyeri { get; set; }
       // public virtual Musteri Musteri { get; set; }

    }
}
