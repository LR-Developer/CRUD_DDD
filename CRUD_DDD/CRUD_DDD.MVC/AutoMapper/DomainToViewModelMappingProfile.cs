using AutoMapper;
using CRUD_DDD.Domain.Entities;
using CRUD_DDD.MVC.ViewModels;

namespace CRUD_DDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        public DomainToViewModelMappingProfile()
        {
            Configure();
        }

        public void Configure()
        {
            CreateMap<CustomerViewModel, Customer>().ReverseMap();
        }
    }
}