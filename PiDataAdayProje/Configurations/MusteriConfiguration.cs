using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PiDataAdayProje.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Configurations
{
    public class MusteriConfiguration : IEntityTypeConfiguration<Musteri>
    {
        public void Configure(EntityTypeBuilder<Musteri> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ad).HasMaxLength(50).HasColumnName("Ad").IsRequired(true);
            builder.Property(x => x.Soyad).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Telefon).HasMaxLength(20).HasColumnName("Telefon").IsRequired(true);
            builder.Property(x => x.CepTelefon).HasMaxLength(20).HasColumnName("Cep Telefonu").IsRequired(true);
            builder.Property(x => x.Mail).HasMaxLength(250).HasColumnName("Mail Adresi").IsRequired(false);
            builder.HasOne<Isyeri>(m => m.Isyeri).WithMany(i => i.Musteriler).HasForeignKey(m => m.IsyeriId);
           // builder.HasMany<Emlak>(m => m.Emlaklar).WithOne(e => e.Musteri);
        }
    }
}
