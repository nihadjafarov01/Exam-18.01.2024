using Exam4.Business.Repositories.Interfaces;
using Exam4.Core.Models;
using Exam4.DAL.Contexts;

namespace Exam4.Business.Repositories.Implements
{
    public class ExpertRepository : GenericRepository<Expert> , IExpertRepository
    {
        public ExpertRepository(Exam4DbContext context) : base(context)
        {
        }
    }
}
