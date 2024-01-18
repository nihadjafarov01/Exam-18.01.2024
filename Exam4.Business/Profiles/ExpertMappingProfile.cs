using AutoMapper;
using Exam4.Business.Helpers;
using Exam4.Business.ViewModels.ExpertVMs;
using Exam4.Core.Models;
using Microsoft.AspNetCore.Hosting;

namespace Exam4.Business.Profiles
{
    public class ExpertMappingProfile : Profile
    {
        public ExpertMappingProfile(IWebHostEnvironment env)
        {
            CreateMap<Expert,ExpertListItemVM>();
            CreateMap<Expert,ExpertUpdateVM>();
            CreateMap<ExpertListItemVM, Expert>();
            CreateMap<ExpertCreateVM, Expert>()
                .ForMember(e => e.ImageUrl, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    if (src.ImageFile != null)
                    {
                        dest.ImageUrl = src.ImageFile.SaveAndProvideName(env);
                    }
                });
            CreateMap<ExpertUpdateVM, Expert>()
                .ForMember(e => e.ImageUrl, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    if (src.ImageFile != null)
                    {
                        dest.ImageUrl = src.ImageFile.SaveAndProvideName(env);
                    }
                });
        }
    }
}
