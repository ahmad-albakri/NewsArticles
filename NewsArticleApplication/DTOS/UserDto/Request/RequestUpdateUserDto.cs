using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsArticlesDomain.shared;

namespace NewsArticleApplication.DTOS.UserDto.Request
{
    public class RequestUpdateUserDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public UserTypeEnum Type { get; set; }
    }
}
