using PiDataAdayProje.Models.Entities;
using PiDataAdayProje.ProjectContext;
using PiDataAdayProje.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Repositories.Concrete
{
    public class MusteriRepository : IMusteriRepository
    {
        private readonly ApplicationDbContext _context;
        public MusteriRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Musteri> Musteriler => _context.Musteriler;

        public Musteri GetById(Guid id) => _context.Musteriler.Find(id);
       

        public bool MusteriEkle(Musteri musteri)
        {
            _context.Musteriler.Add(musteri);
            return _context.SaveChanges() > 0;
        }

        public bool MusteriGuncelle(Musteri musteri)
        {
            _context.Musteriler.Update(musteri);
            return _context.SaveChanges() > 0;
        }

        public bool MusteriSil(Guid id)
        {
            _context.Musteriler.Remove(GetById(id));
            return _context.SaveChanges() > 0;
        }
    }
}
