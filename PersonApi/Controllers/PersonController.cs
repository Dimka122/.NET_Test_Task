using Microsoft.AspNetCore.Mvc;
using PersonApi.DTOs;
using PersonApi.Services;

namespace PersonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult<PersonDTO>> CreatePerson(CreatePersonDTO createPersonDto)
        {
            var person = await _personService.CreatePerson(createPersonDto);
            return CreatedAtAction(nameof(GetFilteredPersons), new { id = person.Id }, person);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetFilteredPersons([FromQuery] GetAllRequest request)
        {
            var persons = await _personService.GetFilteredPersons(request);
            return Ok(persons);
        }
    }
}