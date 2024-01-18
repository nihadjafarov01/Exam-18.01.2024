using AutoMapper;
using Exam4.Business.ViewModels.ExpertVMs;
using Exam4.Core.Models;

namespace Exam4.Business.Profiles
{
    public class ExpertMappingProfile : Profile
    {
        public ExpertMappingProfile()
        {
            CreateMap<Expert,ExpertListItemVM>();
            CreateMap<Expert,ExpertUpdateVM>();
            CreateMap<ExpertUpdateVM, Expert>();
            CreateMap<ExpertCreateVM, Expert>();
            CreateMap<ExpertListItemVM, Expert>();
        }
    }
}
