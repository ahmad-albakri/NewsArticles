using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsArticleInfrasructure.Data;
using NewsArticlesDomain.Entities;
using NewsArticlesDomain.Interfaces;
using NewsArticlesDomain.shared;

namespace NewsArticleInfrasructure.IMplementationRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NewsArticleDbContext _context;
        public UserRepository(NewsArticleDbContext context )
        {
            _context = context;
        }
        public async Task DeleteAsync(int userId)
        {
            await _context.Users.Where(u => u.Id == userId).ExecuteDeleteAsync();
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return user;
        }

        public async Task<User?> GetUserByUserNameAsync(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            return user;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> GetUsersByTypeAsync(UserTypeEnum userType)
        {
            var users = await _context.Users.Where(u => u.Type == userType).ToListAsync();
            return users;
        }

        public async Task<User> InsertAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async
            Task<User> UpdateAsync(User user)
        {
            var newUser = await _context.Users.FindAsync(user.Id);
            if (newUser is null)
            {
                throw new Exception("user not found");
            }

            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            newUser.UserName = user.UserName;
            newUser.Password = user.Password;
            newUser.Type = user.Type;
            await _context.SaveChangesAsync();
            return newUser;
        }
    }
}
