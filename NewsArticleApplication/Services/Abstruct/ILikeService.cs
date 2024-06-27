using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsArticleApplication.DTOS.LikeDto.Request;
using NewsArticleApplication.DTOS.LikeDto.Response;

namespace NewsArticleApplication.Services.Abstruct
{
    public interface ILikeService
    {
        Task<List<ResponseLikeDto>> GetAllLikes();
        Task<ResponseLikeDto> InsertLike(RequestAddLikeDto request, int userId);
        Task DeleteLike(int id);
        Task<ResponseLikeDto> GetLikeById(int id);
    }
}
