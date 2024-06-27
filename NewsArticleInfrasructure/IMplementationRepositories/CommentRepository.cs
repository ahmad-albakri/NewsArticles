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
    public class CommentRepository :ICommentRepository
    {
        private readonly NewsArticleDbContext _context;
        public CommentRepository(NewsArticleDbContext context)
        {
            _context = context;    
        }
        public async Task DeleteAsync(int id)
        {
            await _context.Comments.Where(u => u.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            return comment;
        }

        public async Task<Comment> InsertAsync(Comment comment)
        {
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> UpdateAsync(Comment comment)
        {
            var newComment = await _context.Comments.FindAsync(comment.Id);
            if (newComment is null)
            {
                throw new Exception("Comment not found");
            }
            newComment.Content = comment.Content;
            newComment.UserId = comment.UserId;
            newComment.ArticleId = comment.ArticleId;
            newComment.Date = comment.Date;
            await _context.SaveChangesAsync();
            return newComment;
        }
    }
}
