using Exam4.Core.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace Exam4.Business.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllSync();
        public Task SaveAsync();
        public Task DeleteAsync(int id);
        public Task UpdateAsync(int id, T model);
        public void Create();
        public void CreateAsync(T model);

    }
}
