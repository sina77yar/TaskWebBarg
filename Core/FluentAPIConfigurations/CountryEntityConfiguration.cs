using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.FluentAPIConfigurations
{
    public class CountryEntityConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");

            builder.HasKey(s => s.CountryId);
            builder.Property(p => p.CountryName)
                    .HasColumnName("CountryName")
                    .HasMaxLength(100)
                    .HasColumnOrder(1);
        }
    }

}
