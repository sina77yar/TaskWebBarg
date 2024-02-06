using Core.Entities;
using Core.FluentAPIConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

public class WebBargDbContext : DbContext
{
    public WebBargDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person> Persons => Set<Person>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<Country> Countries => Set<Country>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());
        modelBuilder.Entity<Person>();
        modelBuilder.Entity<Country>();

        modelBuilder.Entity<City>();
       // modelBuilder.Entity<Country>()
       //.HasOne(e => e.Person)
       //.WithOne(e => e.Country);

       // modelBuilder.Entity<City>()
       //.HasOne(e => e.Person)
       //.WithOne(e => e.City);
    }
}