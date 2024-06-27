using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsArticlesDomain.Entities;

namespace NewsArticlesDomain.Interfaces
{
    public interface IArticleRepository
    {
        Task<Article> InsertAsync(Article article);
        Task<Article> UpdateAsync(Article article);
        Task DeleteAsync(int id);
        Task<Article> GetByIdAsync(int id);
        Task<List<Article>> GetAllAsync();
    }
}
