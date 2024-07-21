using Business.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllLikes()
        {
            var likes = _likeService.GetAllLikes();
            return Ok(likes);
        }

        [HttpGet("getlikebyıd")]
        public IActionResult GetLikeById(int id)
        {
            var like = _likeService.GetLikeById(id);
            if (like == null)
            {
                return NotFound();
            }
            return Ok(like);
        }

        [HttpPost("add")]
        public IActionResult AddLike([FromBody] LikeDto likeDto)
        {
            _likeService.AddLike(likeDto);
            return CreatedAtAction(nameof(GetLikeById), new { id = likeDto.PostId }, likeDto);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteLike(int id)
        {
            _likeService.DeleteLike(id);
            return NoContent();
        }



    }
}
