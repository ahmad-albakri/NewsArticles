using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsArticleApplication.DTOS.CommentDto.Request;
using NewsArticleApplication.DTOS.CommentDto.Response;

namespace NewsArticleApplication.Services.Abstruct
{
    public interface ICommentService
    {
        Task<List<ResponseCommentDto>> GetAllComments();
        Task<ResponseCommentDto> GetCommentById(int id);
        Task<ResponseCommentDto> InsertComment(RequestAddCommentDto request, int userId);
        Task<ResponseCommentDto> UpdateComment(RequestUpdateCommentDto request,int userId);
        Task DeleteComment(int id);
    }
}
