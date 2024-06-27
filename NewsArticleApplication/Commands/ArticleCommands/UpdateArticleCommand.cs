using MediatR;
using NewsArticleApplication.DTOS.ArticleDto.Request;
using NewsArticleApplication.DTOS.ArticleDto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticleApplication.Commands.ArticleCommands
{
    public class UpdateArticleCommand: RequestUpdateArticleDto,IRequest<ResponseArticleDto>
    {
    }
}
