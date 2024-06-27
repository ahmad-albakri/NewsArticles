using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using NewsArticleApplication.DTOS.UserDto.Request;
using NewsArticleApplication.DTOS.UserDto.Response;
using NewsArticleApplication.JWT;
using NewsArticleApplication.Services.Abstruct;
using NewsArticlesDomain.Entities;
using NewsArticlesDomain.Exeptions;
using NewsArticlesDomain.Interfaces;
using NewsArticlesDomain.shared;

namespace NewsArticleApplication.Services.Implementation
{
    public class UserService :IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly JwtConfg _jwtConfig;
        public UserService(IUserRepository userRepository, IMapper mapper, IOptions<JwtConfg> jwtConfigOptions)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtConfig = jwtConfigOptions.Value;
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<ResponseUserDto?> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<ResponseUserDto?>(user);
        }

        public async Task<List<ResponseUserDto>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            return _mapper.Map<List<ResponseUserDto>>(users);
        }

        public async Task<List<ResponseUserDto>> GetUsersByTypeAsync(UserTypeEnum userType)
        {
            var users = await _userRepository.GetUsersByTypeAsync(userType);
            return _mapper.Map<List<ResponseUserDto>>(users);

        }

        public async Task<string> LogInUser(RequestLogInUserDto logInInfo)
        {
            var user = await _userRepository.GetUserByUserNameAsync(logInInfo.Username);
            if (user is null || user.Password != logInInfo.Password)
            {
                throw new InvalidLoginCredentialsException();
            }
            var tokenObject = _jwtConfig.GenerateAccessTokenObject(
             claims: new List<Claim>() {
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
             },
             expirationTime: DateTime.UtcNow.AddMinutes(60)
             );
            string token = new JwtSecurityTokenHandler().WriteToken(tokenObject);

            return token;
        }

        public async Task<ResponseUserDto> RegisterUser(RequestRegistrationUserDto request)
        {
            var user = await _userRepository.GetUserByUserNameAsync(request.UserName);
            if (user is not null)
            {
                throw new UsernameAlreadyExistsException();
            }
            var userEntity = _mapper.Map<User>(request);
            await _userRepository.InsertAsync(userEntity);
            return _mapper.Map<ResponseUserDto>(userEntity);
        }

        public async Task<ResponseUserDto> UpdateUser(RequestUpdateUserDto request)
        {
            var user = await _userRepository.GetUserByUserNameAsync(request.UserName);
            if (user is not null)
            {
                throw new UsernameAlreadyExistsException();
            }
            var userEntity = _mapper.Map<User>(request);
            await _userRepository.UpdateAsync(userEntity);
            return _mapper.Map<ResponseUserDto>(userEntity);
        }
    }
}
