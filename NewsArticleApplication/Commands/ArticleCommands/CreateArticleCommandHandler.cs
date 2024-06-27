using MediatR;
using NewsArticleApplication.DTOS.ArticleDto.Response;
using NewsArticleApplication.Services.Abstruct;
using NewsArticlesDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticleApplication.Commands.ArticleCommands
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, ResponseArticleDto>
    {
        private readonly IArticleService _articleServices;

        public CreateArticleCommandHandler(IArticleService articleServices)
        {
            _articleServices = articleServices;
        }
        public async Task<ResponseArticleDto> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _articleServices.InsertArticle(request, request.UserId);
            return article;
        }
    }
}
