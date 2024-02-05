using Infrastructure.Dto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController:ControllerBase
{
    private readonly IPersonService PersonService;

    public PersonController(IPersonService PersonService)
    {
        this.PersonService = PersonService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await PersonService.Get(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await PersonService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PersonDto model)
    {
        var result = await PersonService.Add(model);
        return Ok(result);
    }
}