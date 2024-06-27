using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticleApplication.DTOS.UserDto.Request
{
    public class RequestLogInUserDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
