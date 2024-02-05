using Core.FluentAPIConfigurations;
using Microsoft.EntityFrameworkCore;

public class WebBargDbContext : DbContext
{
    public WebBargDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person> Persons => Set<Person>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
     
        modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());

    }
}