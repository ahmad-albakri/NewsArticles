using MediatR;
using NewsArticleApplication.Services.Abstruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticleApplication.Commands.ArticleCommands
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, bool>
    {
        private readonly IArticleService _articleServices;

        public DeleteArticleCommandHandler(IArticleService articleServices)
        {
            _articleServices = articleServices;
        }
        public async Task<bool> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            await _articleServices.DeleteArticle(request.id);
            return true;
        }
    }
}
