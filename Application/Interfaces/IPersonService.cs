using Infrastructure.Dto;

public interface IPersonService
{
   // ??
    Task<List<PersonDto>> GetAll();
    Task<PersonDto> Get(int id);
    Task<PersonDto> Add(PersonDto model);
}