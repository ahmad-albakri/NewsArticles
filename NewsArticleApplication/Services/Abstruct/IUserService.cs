using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsArticleApplication.DTOS.UserDto.Request;
using NewsArticleApplication.DTOS.UserDto.Response;
using NewsArticlesDomain.shared;

namespace NewsArticleApplication.Services.Abstruct
{
    public interface IUserService
    {
        Task<ResponseUserDto> RegisterUser(RequestRegistrationUserDto request);
        Task<string> LogInUser(RequestLogInUserDto logInInfo);
        Task<ResponseUserDto> UpdateUser(RequestUpdateUserDto request);
        Task<List<ResponseUserDto>> GetUsers();
        Task<ResponseUserDto?> GetUserById(int id);
        Task DeleteUser(int id);
        Task<List<ResponseUserDto>> GetUsersByTypeAsync(UserTypeEnum userType);
    }
}
