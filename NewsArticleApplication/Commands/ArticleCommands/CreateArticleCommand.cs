using MediatR;
using NewsArticleApplication.DTOS.ArticleDto.Request;
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
    public class CreateArticleCommand: RequestAddArticleDto,IRequest<ResponseArticleDto>
    {
        
    }
}
