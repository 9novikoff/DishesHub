using System.Data;
using AutoMapper;
using DishesHub.Api.DAL.Entities;
using DishesHub.Api.DTO;

namespace DishesHub.Api;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<RatePostDto, Rate>();
        CreateMap<Rate, RateGetDto>();
    }
}