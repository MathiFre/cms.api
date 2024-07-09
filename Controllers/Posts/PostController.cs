using CMS.Application.Posts.Interfaces;
using CMS.Application.Posts.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers.Posts
{
    [ApiController]
    [Route("[controller]")]

    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostService _postService;

        public PostController(IPostService postService, ILogger<PostController> logger)
        {
            _postService = postService;
            _logger = logger;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var posts = await _postService.GetAllAsync();
                return Ok(posts);
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
                var post = await _postService.GetByIdAsync(id);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> CreatePostAsync([FromBody] PostCreateDto input)
        {
            try
            {
                var createdPost = await _postService.CreateAsync(input);
                return Ok(createdPost);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> UpdatePost([FromBody] PostDto input)
        {

            try
            {
                var updatedPost = await _postService.UpdateAsync(input);

                return Ok(updatedPost);
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
                var isDeleted = await _postService.DeleteAsync(id);
                if (isDeleted)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Post couldn't be deleted");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
