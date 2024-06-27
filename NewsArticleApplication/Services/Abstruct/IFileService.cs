using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NewsArticleApplication.Services.Abstruct
{
    public interface IFileService
    {
        Task<string> SaveFile(IFormFile file, string relativePath);
        Task<string> SaveFile(byte[] fileAsBytes, string relativePath, string fileName);
    }
}
