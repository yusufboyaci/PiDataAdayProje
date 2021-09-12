using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiDataAdayProje.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Configurations
{
    public class EmlakConfiguration : IEntityTypeConfiguration<Emlak>
    {
        public void Configure(EntityTypeBuilder<Emlak> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EmlakTuru).IsRequired(true).HasMaxLength(100).HasColumnName("Emlak Türü");
            builder.HasOne<Isyeri>(e => e.Isyeri).WithMany(i => i.Emlaklar).HasForeignKey(e => e.IsyeriId);
            //builder.HasOne<Musteri>(e => e.Musteri).WithMany(i => i.Emlaklar).HasForeignKey(e => e.MusteriId);

        }
    }
}
