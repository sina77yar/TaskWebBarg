using Infrastructure.Dto;

public interface IPersonService
{
   // ??
    List<PersonDto> GetAll();
    Task<PersonDto> Get(int id);
    Task<PersonDto> Add(PersonDto model);
}