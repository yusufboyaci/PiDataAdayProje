using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Models.Entities
{
    public class Musteri
    {
        public Guid Id { get; set; }
        public Guid IsyeriId { get; set; }//FK
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Cep Telefonu")]
        public string CepTelefon { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        public virtual Isyeri Isyeri { get; set; }
        //public virtual IEnumerable<Emlak> Emlaklar { get; set; }
    }
}
