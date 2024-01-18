using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Exam4.Business.Helpers
{
    public static class FileSave
    {
        public static string SaveAndProvideName(this IFormFile file, IWebHostEnvironment env)
        {
            string filePath = Path.Combine("imgs", "experts", file.FileName);
            string rootPath = env.WebRootPath;
            using (FileStream fs = System.IO.File.Create(Path.Combine(rootPath, filePath)))
            {
                file.CopyTo(fs);
            }
            return filePath;
        }
    }
}
