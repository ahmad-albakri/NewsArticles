using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsArticlesDomain.Entities;

namespace NewsArticlesDomain.Interfaces
{
    public interface ILikeRepository
    {
        Task<Like> InsertAsync(Like like);
        Task DeleteAsync(int id);
        Task<Like?> GetByIdAsync(int id);
        Task<List<Like>> GetAllAsync();
    }
}
