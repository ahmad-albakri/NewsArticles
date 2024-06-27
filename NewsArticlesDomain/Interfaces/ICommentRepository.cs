using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsArticlesDomain.Entities;

namespace NewsArticlesDomain.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> InsertAsync(Comment comment);
        Task<Comment> UpdateAsync(Comment comment);
        Task DeleteAsync(int id);
        Task<Comment> GetByIdAsync(int id);
        Task<List<Comment>> GetAllAsync();
    }
}
