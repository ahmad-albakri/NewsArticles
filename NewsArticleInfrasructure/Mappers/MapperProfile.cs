using AutoMapper;
using NewsArticleApplication.DTOS.ArticleDto.Request;
using NewsArticleApplication.DTOS.ArticleDto.Response;
using NewsArticleApplication.DTOS.CommentDto.Request;
using NewsArticleApplication.DTOS.CommentDto.Response;
using NewsArticleApplication.DTOS.LikeDto.Request;
using NewsArticleApplication.DTOS.LikeDto.Response;
using NewsArticleApplication.DTOS.UserDto.Request;
using NewsArticleApplication.DTOS.UserDto.Response;
using NewsArticlesDomain.Entities;

namespace NewsArticleInfrasructure.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            
            
            CreateMap<User, RequestLogInUserDto>().ReverseMap();
            CreateMap<User, RequestUpdateUserDto>().ReverseMap();
            CreateMap<User, RequestRegistrationUserDto>().ReverseMap();
            CreateMap<User, ResponseUserDto>().ReverseMap();
            //////////////////////////////////////////////////////////
            CreateMap<Article, RequestAddArticleDto>().ReverseMap();
            CreateMap<Article, RequestUpdateArticleDto>().ReverseMap();
            CreateMap<Article, ResponseArticleDto>().ReverseMap();
            //////////////////////////////////////////////////////////
            CreateMap<Comment, RequestAddCommentDto>().ReverseMap();
            CreateMap<Comment, RequestUpdateCommentDto>().ReverseMap();
            CreateMap<Comment, ResponseCommentDto>().ReverseMap();
            //////////////////////////////////////////////////////////
            CreateMap<Like, RequestAddLikeDto>().ReverseMap();
            CreateMap<Like, ResponseLikeDto>().ReverseMap();

        }
    }
}
