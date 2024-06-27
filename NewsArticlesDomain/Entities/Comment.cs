using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticlesDomain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;
        public int ArticleId { get; set; }
        public Article Article { get; set; } = null!;
    }
}
