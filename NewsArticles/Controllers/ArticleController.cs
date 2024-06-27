using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsArticleApplication.DTOS.ArticleDto.Request;
using NewsArticleApplication.Services.Abstruct;
using NewsArticlesDomain.Exeptions;
using MediatR;
using NewsArticleApplication.Commands.ArticleCommands;
using NewsArticleApplication.Queries.ArticleQueries;

namespace NewsArticles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpPost("Insert")]
        public async Task<IActionResult> InsertArticle([FromForm] CreateArticleCommand request)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
                request.UserId = userId;
                var article = await _mediator.Send(request);
                return Ok(article);
            }
            catch (ThisUserIsNotAuthorizedToPostArticles e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateArticle(UpdateArticleCommand request)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
                request.UserId = userId;
                var article = await _mediator.Send(request);
                return Ok(article);
            }
            catch (ThisUserIsNotAuthorizedToPostArticles e)
            {

                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpDelete]
        public async Task DeleteArticle(DeleteArticleCommand request)
        {
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllArticles(GetAllArticlesQuery request)
        {
            try
            {
                var articles = await _mediator.Send(request);
                return Ok(articles);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetArticleById(GetArticleByIdQuery request)
        {
            try
            {
                var article = await _mediator.Send(request);
                return Ok(article);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
