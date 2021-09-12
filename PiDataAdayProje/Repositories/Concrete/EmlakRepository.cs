using PiDataAdayProje.Models.Entities;
using PiDataAdayProje.ProjectContext;
using PiDataAdayProje.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Repositories.Concrete
{
    public class EmlakRepository : IEmlakRepository
    {
        private readonly ApplicationDbContext _context;
        public EmlakRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Emlak> Emlaklar => _context.Emlaklar;

        public bool EmlakEkle(Emlak emlak)
        {
            _context.Emlaklar.Add(emlak);
            return _context.SaveChanges() > 0;
        }

        public bool EmlakGuncelle(Emlak emlak)
        {
            _context.Emlaklar.Update(emlak);
            return _context.SaveChanges() > 0;
        }

        public bool EmlakSil(int id)
        {
            _context.Emlaklar.Remove(GetById(id));
            return _context.SaveChanges() > 0;
        }

        public Emlak GetById(int id) => _context.Emlaklar.Find(id);

    }
}
