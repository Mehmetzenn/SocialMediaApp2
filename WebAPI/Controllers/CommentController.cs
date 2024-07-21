using Business.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllComments()
        {
            var result = _commentService.GetAllComments();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcommentbyıd")]
        public IActionResult GetCommentById(int id)
        {
            var result = _commentService.GetCommentById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult AddComment([FromBody] CommentDto commentDto)
        {
            _commentService.AddComment(commentDto);
            return CreatedAtAction(nameof(GetCommentById), new { id = commentDto.CommentId }, commentDto);
        }

        [HttpPut("update")]
        public IActionResult UpdateComment(int id, [FromBody] CommentDto commentDto)
        {
            if (id != commentDto.CommentId)
            {
                return BadRequest();
            }
            _commentService.UpdateComment(commentDto);
            return NoContent();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteComment(int id)
        {
            _commentService.DeleteComment(id);
            return NoContent();
        }

    }
}
