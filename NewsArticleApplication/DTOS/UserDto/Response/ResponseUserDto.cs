using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsArticlesDomain.shared;

namespace NewsArticleApplication.DTOS.UserDto.Response
{
    public class ResponseUserDto
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required UserTypeEnum Type { get; set; }
    }
}
