using Exam4.Business.ViewModels.AuthVMs;

namespace Exam4.Business.Repositories.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> Register(RegisterVM vm);
        public Task<bool> Login(LoginVM vm);
        public Task<bool> CreateInit();
    }
}
