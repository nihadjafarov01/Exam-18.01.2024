using Exam4.Core.Models.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Exam4.Business.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T model);
        Task<T> UpdateAsync(int id);
        Task CreateAsync(T model);
        Task DeleteAsync(int id);
        Task SaveAsync();

    }
}
