using PiDataAdayProje.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Repositories.Abstract
{
    public interface IIsyeriRepository
    {
        IQueryable<Isyeri> Isyeriler { get; }
        Isyeri GetById(Guid id);
        bool IsyeriEkle(Isyeri isyeri);
        bool IsyeriGuncelle(Isyeri isyeri);
        bool IsyeriSil(Guid id);
    }
}
