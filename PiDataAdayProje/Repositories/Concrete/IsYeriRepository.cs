using PiDataAdayProje.Models.Entities;
using PiDataAdayProje.ProjectContext;
using PiDataAdayProje.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Repositories.Concrete
{
    public class IsYeriRepository : IIsyeriRepository
    {
        private readonly ApplicationDbContext _context;
        public IsYeriRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Isyeri> Isyeriler => _context.Isyeriler;

        public Isyeri GetById(int id) => _context.Isyeriler.Find(id);


        public bool IsyeriEkle(Isyeri isyeri)
        {
            _context.Isyeriler.Add(isyeri);
            return _context.SaveChanges() > 0;
        }

        public bool IsyeriGuncelle(Isyeri isyeri)
        {
            _context.Isyeriler.Update(isyeri);
            return _context.SaveChanges() > 0;
        }

        public bool IsyeriSil(int id)
        {
            _context.Isyeriler.Remove(GetById(id));
            return _context.SaveChanges() > 0;
        }
    }
}
