using AutoMapper;
using UserApp.UserApp.Domain.Models;
using UserApp.UserApp.Resources.Show;
using UserApp.UserApp.Services.Communication.Responses;

namespace UserApp.UserApp.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<User, UserResource>();
        CreateMap<User, AuthReponse>();
    }
}