using AutoMapper;
using UserApp.UserApp.Domain.Models;
using UserApp.UserApp.Domain.Services.Communication;

namespace UserApp.UserApp.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<RegisterRequest, User>();
    }
}