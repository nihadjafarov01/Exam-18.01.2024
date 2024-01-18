using Exam4.Core.Models.Common;

namespace Exam4.Core.Models
{
    public class ExpertSocialMedia : BaseModel
    {
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }
        public int SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; }
    }
}
