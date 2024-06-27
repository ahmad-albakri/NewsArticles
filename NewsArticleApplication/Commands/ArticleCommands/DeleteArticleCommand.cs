using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticleApplication.Commands.ArticleCommands
{
    public class DeleteArticleCommand:IRequest<bool>
    {
        public int id { get; set; }
    }
}
