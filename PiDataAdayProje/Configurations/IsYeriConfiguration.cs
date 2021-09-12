using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiDataAdayProje.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Configurations
{
    public class IsYeriConfiguration : IEntityTypeConfiguration<Isyeri>
    {
        public void Configure(EntityTypeBuilder<Isyeri> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsletmeAdi).HasMaxLength(100).HasColumnName("İşletme Adı").IsRequired(true);
            builder.Property(x => x.Yetkili).HasMaxLength(100).HasColumnName("Yetkili Kişi").IsRequired(true);
            builder.Property(x => x.Adres).HasColumnName("Adres").IsRequired(true);
            builder.Property(x => x.Telefon).HasMaxLength(20).HasColumnName("Telefon No").IsRequired(true);
            builder.Property(x => x.Fax).HasMaxLength(30).HasColumnName("Fax No").IsRequired(true);
            builder.HasMany<Musteri>(m => m.Musteriler).WithOne(i => i.Isyeri);
            builder.HasMany<Emlak>(e => e.Emlaklar).WithOne(i => i.Isyeri);
        }
    }
}
