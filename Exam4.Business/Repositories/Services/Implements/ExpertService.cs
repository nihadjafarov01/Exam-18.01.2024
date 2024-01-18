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

        public async Task<IEnumerable<ExpertListItemVM>> GetAllSync()
        {
            var data = await _repo.GetAllAsync();
            var rdata = _mapper.Map<IEnumerable<ExpertListItemVM>>(data);
            return rdata;
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, ExpertUpdateVM vm)
        {
            var model = await _repo.GetByIdAsync(id);
            var rmodel = _mapper.Map(vm,model);
            await _repo.UpdateAsync(rmodel);
        }

        public async Task<ExpertUpdateVM> UpdateAsync(int id)
        {
            var model = await _repo.UpdateAsync(id);
            return _mapper.Map<ExpertUpdateVM>(model);
        }

        public async Task CreateAsync(ExpertCreateVM vm)
        {
            var model = _mapper.Map<Expert>(vm);
            await _repo.CreateAsync(model);
        }
    }
}
