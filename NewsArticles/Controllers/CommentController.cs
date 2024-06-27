using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsArticleApplication.DTOS.CommentDto.Request;
using NewsArticleApplication.Services.Abstruct;

namespace NewsArticles.Controllers
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
        [Authorize]
        [HttpPost("Insert")]
        public async Task<IActionResult> InsertComment(RequestAddCommentDto request)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
                var comment = await _commentService.InsertComment(request, userId);
                return Ok(comment);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateComment(RequestUpdateCommentDto request)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
                var comment = await _commentService.UpdateComment(request, userId);
                return Ok(comment);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpDelete]
        public async Task DeleteComment(int id)
        {
            try
            {
                await _commentService.DeleteComment(id);
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
                var comments = await _commentService.GetAllComments();
                return Ok(comments);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            try
            {
                var comment = await _commentService.GetCommentById(id);
                return Ok(comment);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
