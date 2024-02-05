using AutoMapper;
using Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;

public class PersonService : IPersonService
{
    private readonly WebBargDbContext dbContext;
    private readonly IMapper mapper;

    //repository ??
    //unit of work ??

    public PersonService(WebBargDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    //DTO => Data Transfer Object
    public async Task<PersonDto> Add(PersonDto model)
    {
        //PersonDto to Person AutoMapper ??

        var Person = mapper.Map<Person>(model);

        await dbContext.AddAsync(Person);
        await dbContext.SaveChangesAsync();

        model.Id = Person.Id;

        return model;
    }

    public async Task<PersonDto> Get(int id)
    {
        var Person = await dbContext.Persons.FindAsync(id);
        var model = mapper.Map<PersonDto>(Person);
        return model;
    }

    public async Task<List<PersonDto>> GetAll()
    {


        var Persons = await dbContext.Persons.ToListAsync();

        var result = mapper.Map<List<PersonDto>>(Persons);

        return result;
    }
}