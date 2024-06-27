using MediatR;
using NewsArticleApplication.DTOS.ArticleDto.Response;
using NewsArticleApplication.Services.Abstruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticleApplication.Queries.ArticleQueries
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, ResponseArticleDto>
    {
        private readonly IArticleService _articleServices;

        public GetArticleByIdQueryHandler(IArticleService articleServices)
        {
            _articleServices = articleServices;
        }
        public async Task<ResponseArticleDto> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleServices.GetArticleById(request.Id);
            return article;
        }
    }
}
