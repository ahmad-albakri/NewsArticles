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
    public class ArticleRepository :IArticleRepository
    {
        private readonly NewsArticleDbContext _context;

        public ArticleRepository(NewsArticleDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Articles.Where(u => u.Id == id).ExecuteDeleteAsync();

        }

        public async Task<List<Article>> GetAllAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article> GetByIdAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            return article;
        }

        public async Task<Article> InsertAsync(Article article)
        {
            await _context.AddAsync(article);
            await _context.SaveChangesAsync();
            return article;
        }

        public async Task<Article> UpdateAsync(Article article)
        {
            var newArticle = await _context.Articles.FindAsync(article.Id);
            if (newArticle is null)
            {
                throw new Exception("asd");
            }
            newArticle.Title = article.Title;
            newArticle.Content = article.Content;
            newArticle.Date = article.Date;
            newArticle.UserId = article.UserId;
            await _context.SaveChangesAsync();
            return newArticle;

        }
    }
}
