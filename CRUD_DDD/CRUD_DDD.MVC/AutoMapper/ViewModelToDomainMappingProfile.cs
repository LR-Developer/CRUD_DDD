using AutoMapper;
using CRUD_DDD.Domain.Entities;
using CRUD_DDD.MVC.ViewModels;

namespace CRUD_DDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        public ViewModelToDomainMappingProfile()
        {
            Configure();
        }

        public void Configure()
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
        }
    }
}