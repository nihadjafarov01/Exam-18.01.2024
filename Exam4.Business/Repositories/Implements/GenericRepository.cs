using Exam4.Business.Repositories.Interfaces;
using Exam4.Core.Models.Common;
using Exam4.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Exam4.Business.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        Exam4DbContext _context { get; }
        public GenericRepository(Exam4DbContext context)
        {
            _context = context;
        }
        DbSet<T> Table => _context.Set<T>();
        public async Task<T> GetByIdAsync(int id)
        {
            
            return await Table.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllSync()
        {
            return await Table.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var model = await Table.FindAsync(id);
            Table.Remove(model);
            await SaveAsync();
        }

        public async Task UpdateAsync(int id, T model)
        {
            Table.Update(model);
            await SaveAsync();
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public async void CreateAsync(T model)
        {
            await Table.AddAsync(model);
            await SaveAsync();
        }
    }
}
