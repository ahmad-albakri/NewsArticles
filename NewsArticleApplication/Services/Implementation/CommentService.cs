using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NewsArticleApplication.DTOS.CommentDto.Request;
using NewsArticleApplication.DTOS.CommentDto.Response;
using NewsArticleApplication.Services.Abstruct;
using NewsArticlesDomain.Entities;
using NewsArticlesDomain.Interfaces;

namespace NewsArticleApplication.Services.Implementation
{
    public class CommentService :ICommentService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper,IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task DeleteComment(int id)
        {
            await _commentRepository.DeleteAsync(id);
        }

        public async Task<List<ResponseCommentDto>> GetAllComments()
        {
            var comments = await _commentRepository.GetAllAsync();
            return _mapper.Map<List<ResponseCommentDto>>(comments);
        }

        public async Task<ResponseCommentDto> GetCommentById(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            return _mapper.Map<ResponseCommentDto>(comment);
        }

        public async Task<ResponseCommentDto> InsertComment(RequestAddCommentDto request,int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            var commentEntity = _mapper.Map<Comment>(request);
            commentEntity.UserId = userId;
            await _commentRepository.InsertAsync(commentEntity);
            return _mapper.Map<ResponseCommentDto>(commentEntity);
        }

        public async Task<ResponseCommentDto> UpdateComment(RequestUpdateCommentDto request, int userId)
        {
            var commentEntity = _mapper.Map<Comment>(request);
            commentEntity.UserId = userId;
            await _commentRepository.UpdateAsync(commentEntity);
            return _mapper.Map<ResponseCommentDto>(commentEntity);
        }
    }
}
