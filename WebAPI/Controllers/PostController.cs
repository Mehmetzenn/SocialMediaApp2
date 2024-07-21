using Business.Abstracts;
using Business.Concretes;
using DataAccess.Concretes;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllPosts()
        {
            var posts = _postService.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("gebypostıd")]
        public IActionResult GetPostById(int id)
        {
            var result = _postService.GetPostWithDetails(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult AddPost([FromBody] PostDto postDto)
        {
            _postService.AddPost(postDto);
            return CreatedAtAction(nameof(GetPostById), new { id = postDto.PostId }, postDto);
        }

        [HttpPut("update")]
        public IActionResult UpdatePost(int id, [FromBody] PostDto postDto)
        {
            if (id != postDto.PostId)
            {
                return BadRequest();
            }
            _postService.UpdatePost(postDto);
            return NoContent();
        }

        [HttpDelete("delete")]
        public IActionResult DeletePost(int id)
        {
            _postService.DeletePost(id);
            return NoContent();
        }

    }
}
