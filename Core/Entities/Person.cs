using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;


public class Person
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; }
    [MaxLength(200)]
    [Required]
    public string LastName { get; set; }
    //public ICollection<City> Cities { get; set; }
    //public ICollection<Country> Countries { get; set; }
    public string? ImageName { get; set; }
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public City? City { get; set; }
    public int CityId { get; set; }
    //public virtual FileInfo[]? FileInfo { get; set; }
}