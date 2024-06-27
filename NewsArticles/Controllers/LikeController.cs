using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsArticleApplication.DTOS.LikeDto.Request;
using NewsArticleApplication.Services.Abstruct;

namespace NewsArticles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeServices;

        public LikeController(ILikeService likeServices)
        {
            _likeServices = likeServices;
        }
        [Authorize]
        [HttpPost("Insert")]
        public async Task<IActionResult> InsertLike(RequestAddLikeDto request)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

                var like = await _likeServices.InsertLike(request, userId);
                return Ok(like);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpDelete]
        public async Task DeleteLike(int id)
        {
            try
            {
                await _likeServices.DeleteLike(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            try
            {
                var likes = await _likeServices.GetAllLikes();
                return Ok(likes);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetLikeById(int id)
        {
            try
            {
                var like = await _likeServices.GetLikeById(id);
                return Ok(like);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
