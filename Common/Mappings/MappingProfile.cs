using ApplicationShared.Activities.Commands;
using AutoMapper;
using Models.InputModels;

namespace Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ActivityInputModel, CreateActivityCommand>();
        }
    }
}
