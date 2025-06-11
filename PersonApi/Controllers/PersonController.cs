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

        /// <summary>
        /// Получить всех людей
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetAll()
        {
            var persons = await _personService.GetAllPersons();
            return Ok(persons);
        }

        /// <summary>
        /// Получить отфильтрованный список людей
        /// </summary>
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetFiltered([FromQuery] GetAllRequest request)
        {
            var persons = await _personService.GetFilteredPersons(request);
            return Ok(persons);
        }

        /// <summary>
        /// Получить человека по ID
        /// </summary>
        /// <param name="id">ID человека</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDTO>> GetById(long id)
        {
            var person = await _personService.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        /// <summary>
        /// Создать нового человека
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PersonDTO>> Create(CreatePersonDTO createPersonDto)
        {
            var person = await _personService.CreatePerson(createPersonDto);
            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }

        /// <summary>
        /// Обновить данные человека
        /// </summary>
        /// <param name="id">ID человека</param>
        /// <param name="updatePersonDto">Данные для обновления</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, UpdatePersonDTO updatePersonDto)
        {
            if (id != updatePersonDto.Id)
            {
                return BadRequest();
            }

            var result = await _personService.UpdatePerson(updatePersonDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Удалить человека
        /// </summary>
        /// <param name="id">ID человека</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _personService.DeletePerson(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}