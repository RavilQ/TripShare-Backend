using ApiPracitce.Dtos.CategoryDtos;
using ApiPracitce.Dtos.CityDtos;
using ApiPractice.Core.Entities;
using AutoMapper;

namespace ApiPracitce.Profiles
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Category, CategoryGetDto>();
            CreateMap<CategoryPostDto, Category>();
            CreateMap<City, CityGetListItemDto>();
            CreateMap<City, CityGetDto>();
        }
    }
}
