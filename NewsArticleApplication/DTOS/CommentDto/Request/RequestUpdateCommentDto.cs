using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticleApplication.DTOS.CommentDto.Request
{
    public class RequestUpdateCommentDto
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime Date { get; set; }
        public int ArticleId { get; set; }
    }
}
