using Exam4.Core.Models.Common;

namespace Exam4.Core.Models
{
    public class SocialMedia : BaseModel
    {
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public IEnumerable<ExpertSocialMedia> Experts { get; set; }

    }
}
