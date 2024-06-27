using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsArticleInfrasructure.Data;
using NewsArticlesDomain.Entities;
using NewsArticlesDomain.Interfaces;

namespace NewsArticleInfrasructure.IMplementationRepositories
{
    public class LikeRepository :ILikeRepository

    {
        private readonly NewsArticleDbContext _context;

        public LikeRepository(NewsArticleDbContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int id)
        {
            var like = await _context.likes.FindAsync(id);
            var article = await _context.Articles.FindAsync(like.ArticleId);
            if (article is null)
            {
                throw new Exception("There is no like");
            }
            article.LikesCount = article.LikesCount - 1;
            await _context.SaveChangesAsync();
            await _context.likes.Where(u => u.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Like>> GetAllAsync()
        {
            return await _context.likes.ToListAsync();
        }

        public async Task<Like?> GetByIdAsync(int id)
        {
            var like = await _context.likes.FindAsync(id);
            return like;
        }

        public async Task<Like> InsertAsync(Like like)
        {
            await _context.AddAsync(like);
            var article = await _context.Articles.FindAsync(like.ArticleId);
            if (article is null)
            {
                throw new Exception("There is no artivle");
            }
            article.LikesCount = article.LikesCount + 1;
            await _context.SaveChangesAsync();
            return like;
        }

       
    }
}
