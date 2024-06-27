using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NewsArticleApplication.DTOS.LikeDto.Request;
using NewsArticleApplication.DTOS.LikeDto.Response;
using NewsArticleApplication.Services.Abstruct;
using NewsArticlesDomain.Entities;
using NewsArticlesDomain.Interfaces;

namespace NewsArticleApplication.Services.Implementation
{
    public class LikeService :ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        public LikeService(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        public async Task DeleteLike(int id)
        {
            await _likeRepository.DeleteAsync(id);
        }

        public async Task<List<ResponseLikeDto>> GetAllLikes()
        {
            var likes = await _likeRepository.GetAllAsync();
            return _mapper.Map<List<ResponseLikeDto>>(likes);
        }

        public async Task<ResponseLikeDto> GetLikeById(int id)
        {
            var like = await _likeRepository.GetByIdAsync(id);
            return _mapper.Map<ResponseLikeDto>(like);
        }

        public async Task<ResponseLikeDto> InsertLike(RequestAddLikeDto request,int userId)
        {
            var likeEntity = _mapper.Map<Like>(request);
            likeEntity.UserId=userId;
            await _likeRepository.InsertAsync(likeEntity);
            return _mapper.Map<ResponseLikeDto>(likeEntity);
        }

    }
}
