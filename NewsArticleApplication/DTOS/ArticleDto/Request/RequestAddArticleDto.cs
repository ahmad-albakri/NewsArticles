using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NewsArticleApplication.DTOS.ArticleDto.Request
{
    public class RequestAddArticleDto
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime Date { get; set; }
        public required IFormFile File { get; set; }
        public int UserId { get; set; }
    }
}
