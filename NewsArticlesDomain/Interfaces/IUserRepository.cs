using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsArticlesDomain.Entities;
using NewsArticlesDomain.shared;

namespace NewsArticlesDomain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> InsertAsync(User user);
        Task<List<User>> GetUsersAsync();
        Task<User> UpdateAsync(User user);
        Task DeleteAsync(int userId);
        Task<User?> GetUserByIdAsync(int userId);
        Task<User?> GetUserByUserNameAsync(string userName);
        Task<List<User>> GetUsersByTypeAsync(UserTypeEnum userType);
    }
}
