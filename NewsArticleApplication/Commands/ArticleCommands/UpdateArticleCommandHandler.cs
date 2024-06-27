using MediatR;
using NewsArticleApplication.DTOS.ArticleDto.Response;
using NewsArticleApplication.Services.Abstruct;
using NewsArticlesDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticleApplication.Commands.ArticleCommands
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, ResponseArticleDto>
    {
        private readonly IArticleService _articleServices;

        public UpdateArticleCommandHandler(IArticleService articleServices)
        {
            _articleServices = articleServices;
        }
        public async Task<ResponseArticleDto> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {

            var article = await _articleServices.UpdateArticle(request, request.UserId);
            return article;
        }
    }
}
