using PiDataAdayProje.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Models.Entities
{
    public class Emlak
    {
        public Guid Id { get; set; }
        public Guid IsyeriId { get; set; }//FK
        public Guid MusteriId { get; set; }//FK
        public string EmlakTuru { get; set; }
        public ulong Metrekare { get; set; }
        public int OdaSayisi { get; set; }
        public int Kat { get; set; }
        public int BinaKati { get; set; }
        public IsinmaTuru IsinmaTuru { get; set; }
    
        public virtual Isyeri Isyeri { get; set; }
       // public virtual Musteri Musteri { get; set; }

    }
}
