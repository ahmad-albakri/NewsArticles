using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsArticlesDomain.shared;

namespace NewsArticlesDomain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required string UserName { get; set; }
        public required string Password { get; set; }
        public UserTypeEnum Type { get; set; }
        public ICollection<Article> Articles { get; set; } = new List<Article>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
