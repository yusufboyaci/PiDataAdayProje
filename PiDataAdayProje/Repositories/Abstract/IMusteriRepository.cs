using PiDataAdayProje.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Repositories.Abstract
{
    public interface IMusteriRepository
    {
        IQueryable<Musteri> Musteriler { get; }
        Musteri GetById(Guid id);
        bool MusteriEkle(Musteri musteri);
        bool MusteriGuncelle(Musteri musteri);
        bool MusteriSil(Guid id);
    }
}
