using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class RequestToModelProfile : Profile
    {
        public RequestToModelProfile()
        {
            CreateMap<UserModel, UsuarioRequest>()
                .ReverseMap();
        }
    }
}
