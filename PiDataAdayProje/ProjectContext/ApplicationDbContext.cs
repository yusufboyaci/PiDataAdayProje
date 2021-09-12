using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PiDataAdayProje.Configurations;
using PiDataAdayProje.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.ProjectContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Emlak> Emlaklar { get; set; }
        public DbSet<Isyeri> Isyeriler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmlakConfiguration());
            modelBuilder.ApplyConfiguration(new IsYeriConfiguration());
            modelBuilder.ApplyConfiguration(new MusteriConfiguration());
            base.OnModelCreating(modelBuilder);  
        }
    }
}
