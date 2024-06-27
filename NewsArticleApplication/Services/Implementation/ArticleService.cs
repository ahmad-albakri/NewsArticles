using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using NewsArticleApplication.DTOS.ArticleDto.Request;
using NewsArticleApplication.DTOS.ArticleDto.Response;
using NewsArticleApplication.Services.Abstruct;
using NewsArticlesDomain.Entities;
using NewsArticlesDomain.Exeptions;
using NewsArticlesDomain.Interfaces;
using NewsArticlesDomain.shared;

namespace NewsArticleApplication.Services.Implementation
{
    public class ArticleService : IArticleService
    {
        private readonly IFileService _fileService;
        private readonly IUserRepository _userRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper, IUserRepository userRepository, IFileService fileService)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _fileService = fileService;
        }

        public async Task DeleteArticle(int id)
        {
            await _articleRepository.DeleteAsync(id);
        }

        public async Task<List<ResponseArticleDto>> GetAllArticles()
        {
            var articles = await _articleRepository.GetAllAsync();
            return _mapper.Map<List<ResponseArticleDto>>(articles);
        }

        public async Task<ResponseArticleDto> GetArticleById(int id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            return _mapper.Map<ResponseArticleDto>(article);
        }

        public async Task<ResponseArticleDto> InsertArticle(RequestAddArticleDto article, int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user.Type != UserTypeEnum.Writer)
            {
                throw new ThisUserIsNotAuthorizedToPostArticles();
            }
            var articleEntity = _mapper.Map<Article>(article);

            articleEntity.ImagePath = await SaveFile(article.File);
            articleEntity.UserId = userId;
            await _articleRepository.InsertAsync(articleEntity);
            return _mapper.Map<ResponseArticleDto>(articleEntity);
        }

        public async Task<ResponseArticleDto> UpdateArticle(RequestUpdateArticleDto request, int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user.Type != UserTypeEnum.Writer)
            {
                throw new ThisUserIsNotAuthorizedToPostArticles();
            }
            var articleEntity = _mapper.Map<Article>(request);
            articleEntity.UserId=userId;
            await _articleRepository.UpdateAsync(articleEntity);

            return _mapper.Map<ResponseArticleDto>(articleEntity);
        }
        public async Task<string> SaveFile(IFormFile file)
        {
            var filePath = await _fileService.SaveFile(file, "articles");
            return filePath;
        }

    }
}
