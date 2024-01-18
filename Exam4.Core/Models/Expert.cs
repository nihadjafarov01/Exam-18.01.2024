using Exam4.Core.Models.Common;

namespace Exam4.Core.Models
{
    public class Expert : BaseModel
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<ExpertSocialMedia>? SocialMedias { get; set; }
    }
}
