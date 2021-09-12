using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Models.Entities
{
    public class Isyeri
    {
        public Guid Id { get; set; }
        public string IsletmeAdi { get; set; }
        public string Yetkili { get; set; }
        [DataType(DataType.Text)]
        public string Adres { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Fax { get; set; }

        public virtual IEnumerable<Musteri> Musteriler { get; set; }
        public virtual IEnumerable<Emlak> Emlaklar { get; set; }
    }
}
