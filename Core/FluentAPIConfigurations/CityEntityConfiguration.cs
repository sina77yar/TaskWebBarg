using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using System.Reflection.Emit;

namespace Core.FluentAPIConfigurations
{
    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");

            builder.HasKey(s => s.CityId);
            builder.Property(p => p.CityName)
                    .HasColumnName("CityName")
                    .HasMaxLength(100)
                    .HasColumnOrder(1);



        }
    }
}
