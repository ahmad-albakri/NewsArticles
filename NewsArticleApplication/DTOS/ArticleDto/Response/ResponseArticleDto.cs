using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticleApplication.DTOS.ArticleDto.Response
{
    public class ResponseArticleDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public int LikesCount { get; set; } = 0;
        public string ImagePath { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
