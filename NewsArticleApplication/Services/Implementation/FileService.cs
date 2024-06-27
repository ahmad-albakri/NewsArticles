using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NewsArticleApplication.Services.Abstruct;

namespace NewsArticleApplication.Services.Implementation
{
    public class FileService :IFileService
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> SaveFile(IFormFile file, string relativePath)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = $"file-{DateTime.UtcNow.ToString("ddMMyyyy-hhmmss")}{fileExtension}";
            using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            var filePath = await SaveFile(memoryStream.ToArray(), relativePath, fileName);
            return filePath;
        }

        public async Task<string> SaveFile(byte[] fileAsBytes, string relativePath, string fileName)
        {
            var contentPath = webHostEnvironment.WebRootPath;

            var pathWithRoot = Path.Combine(contentPath, relativePath);
            if (!Directory.Exists(pathWithRoot))
            {
                Directory.CreateDirectory(pathWithRoot);
            }
            var fileWithPath = Path.Combine(pathWithRoot, fileName);
            var stream = new FileStream(fileWithPath, FileMode.Create);
            await stream.WriteAsync(fileAsBytes);
            stream.Close();
            return relativePath + "/" + fileName;
        }
    }
}
