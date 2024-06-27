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
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, List<ResponseArticleDto>>
    {
        private readonly IArticleService _articleServices;

        public GetAllArticlesQueryHandler(IArticleService articleServices)
        {
            _articleServices = articleServices;
        }
        public async Task<List<ResponseArticleDto>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await _articleServices.GetAllArticles();
            return articles;
        }
    }
}
