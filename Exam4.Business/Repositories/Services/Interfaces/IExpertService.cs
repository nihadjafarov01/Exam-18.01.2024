using Exam4.Business.ViewModels.ExpertVMs;

namespace Exam4.Business.Repositories.Services.Interfaces
{
    public interface IExpertService
    {
        public Task<IEnumerable<ExpertListItemVM>> GetAllSync();
        public Task DeleteAsync(int id);
        public Task<ExpertUpdateVM> UpdateAsync(int id);
        public Task UpdateAsync(int id, ExpertUpdateVM vm);
        public Task CreateAsync(ExpertCreateVM vm);
    }
}
