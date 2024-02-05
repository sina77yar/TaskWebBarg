using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.FluentAPIConfigurations;
public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Persons");

        builder.HasKey(s => s.Id);
        builder.Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(100)
                .HasColumnOrder(1);
        builder.Property(p => p.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(200)
                    .HasColumnOrder(2);
        builder.Property(p => p.Country)
        .HasColumnName("Country")
        .HasMaxLength(100)
        .HasColumnOrder(3);
        builder.Property(p => p.City)
        .HasColumnName("City")
        .HasMaxLength(100)
        .HasColumnOrder(4);
        builder.Property(p => p.ImageName)
        .HasColumnName("ImageName")
        .HasMaxLength(200)
        .HasColumnOrder(5);

    }
}
