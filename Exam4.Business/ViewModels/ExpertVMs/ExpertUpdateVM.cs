using Exam4.Core.Models;
using Microsoft.AspNetCore.Http;

namespace Exam4.Business.ViewModels.ExpertVMs
{
    public class ExpertUpdateVM
    {
        public string Fullname { get; set; }
        public IFormFile? ImageFile { get; set; }
        public IEnumerable<ExpertSocialMedia>? SocialMedias { get; set; }
    }
}
