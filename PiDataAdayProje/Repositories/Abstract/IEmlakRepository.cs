using PiDataAdayProje.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Repositories.Abstract
{
    public interface IEmlakRepository
    {
        IQueryable<Emlak> Emlaklar { get; }
        Emlak GetById(Guid id);
        bool EmlakEkle(Emlak emlak);
        bool EmlakGuncelle(Emlak emlak);
        bool EmlakSil(Guid id);

    }
}
