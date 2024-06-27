using MediatR;
using NewsArticleApplication.DTOS.ArticleDto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticleApplication.Queries.ArticleQueries
{
    public class GetArticleByIdQuery:IRequest<ResponseArticleDto>
    {
        public int Id { get; set; }
    }
}
