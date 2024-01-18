using Exam4.Core.Models;

namespace Exam4.Business.ViewModels.ExpertVMs
{
    public class ExpertListItemVM
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<ExpertSocialMedia>? SocialMedias { get; set; }
    }
}
