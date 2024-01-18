using AutoMapper;
using Exam4.Business.Repositories.Interfaces;
using Exam4.Business.Repositories.Services.Interfaces;
using Exam4.Business.ViewModels.ExpertVMs;
using Exam4.Core.Models;

namespace Exam4.Business.Repositories.Services.Implements
{
    public class ExpertService : IExpertService
    {
        IExpertRepository _repo {  get; }
        IMapper _mapper { get; }

        public ExpertService(IExpertRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Create(ExpertCreateVM vm)
        {
            var model = _mapper.Map<Expert>(vm);
             _repo.CreateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
             await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<ExpertListItemVM>> GetAllSync()
        {
            var data = await _repo.GetAllSync();
            var rdata = _mapper.Map<IEnumerable<ExpertListItemVM>>(data);
            return rdata;
        }


        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, ExpertUpdateVM vm)
        {
            Expert model = _mapper.Map<Expert>(vm);
            await _repo.UpdateAsync(id, model);
        }

        public async Task<ExpertUpdateVM> UpdateAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);
            return _mapper.Map<ExpertUpdateVM>(data);
        }
    }
}
