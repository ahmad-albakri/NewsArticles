using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsArticleApplication.DTOS.ArticleDto.Request;
using NewsArticleApplication.DTOS.ArticleDto.Response;

namespace NewsArticleApplication.Services.Abstruct
{
    public interface IArticleService
    {
        Task<ResponseArticleDto> InsertArticle(RequestAddArticleDto article, int userId);
        Task<ResponseArticleDto> UpdateArticle(RequestUpdateArticleDto request,int userId);
        Task DeleteArticle(int id);
        Task<ResponseArticleDto> GetArticleById(int id);
        Task<List<ResponseArticleDto>> GetAllArticles();
    }
}
