using Core.Entities;

namespace Infrastructure.Dto;
public class PersonDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public City? City { get; set; }
    public int CityId { get; set; }
    public string ImageName { get; set; }
    public string Percentage { get; set; }
    public virtual FileInfo[]? FileInfo { get; set; }
}