using Exam4.Core.Models;

namespace Exam4.Business.ViewModels.ExpertVMs
{
    public class ExpertCreateVM
    {
        public string Fullname { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<ExpertSocialMedia>? SocialMedias { get; set; }
    }
}
