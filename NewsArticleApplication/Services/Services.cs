using Microsoft.Extensions.DependencyInjection;
using NewsArticleApplication.Services.Abstruct;
using NewsArticleApplication.Services.Implementation;
using NewsArticlesDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticleApplication.Services
{
    public static class Services
    {
        public static void AddLayer(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IFileService, FileService>();
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            }); 
        }
    }
}
