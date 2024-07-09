using CMS.Application.Tags;
using CMS.Application.Tags.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers.Posts
{
    [ApiController]
    [Route("[controller]")]

    public class TagController : ControllerBase
    {
        private readonly ILogger<TagController> _logger;
        private readonly ITagService _tagService;

        public TagController(ITagService tagService, ILogger<TagController> logger)
        {
            _tagService = tagService;
            _logger = logger;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tags = await _tagService.GetAllAsync();

                return Ok(tags);
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
                var tag = _tagService.GetByIdAsync(id);
                return Ok(tag);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpPost()]
        public async Task<IActionResult> CreateTag([FromBody] TagCreateDto input)
        {
            try
            {
                var createdTag = await _tagService.CreateAsync(input);
                return Ok(createdTag);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpPut()]
        public async Task<IActionResult> UpdatePost([FromBody] TagDto input)
        {
            try
            {
                var updatedTag = await _tagService.UpdateAsync(input);
                return Ok(updatedTag);
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
                var isDeleted = await _tagService.DeleteAsync(id);
                if (isDeleted)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Tag couldn't be deleted");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
