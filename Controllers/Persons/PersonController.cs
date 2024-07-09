using CMS.Application.Persons.Interfaces;
using CMS.Application.Persons.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers.Persons
{
    [ApiController]
    [Route("[controller]")]

    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _PersonService;

        public PersonController(IPersonService PersonService, ILogger<PersonController> logger)
        {
            _PersonService = PersonService;
            _logger = logger;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Persons = await _PersonService.GetAllAsync();

                return Ok(Persons);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var Person = _PersonService.GetByIdAsync(id);
                return Ok(Person);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost()]
        public async Task<IActionResult> CreatePerson([FromBody] PersonCreateDto input)
        {
            try
            {
                var createdPerson = await _PersonService.CreateAsync(input);
                return Ok(createdPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut()]
        public async Task<IActionResult> UpdatePost([FromBody] PersonDto input)
        {
            try
            {
                var updatedPerson = await _PersonService.UpdateAsync(input);
                return Ok(updatedPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("ById/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {

            try
            {
                var isDeleted = await _PersonService.DeleteAsync(id);
                if (isDeleted)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Person couldn't be deleted");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
