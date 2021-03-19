using Api.Domain.Entities;
using Api.Domain.Models.User;
using Api.Service.Test.Usuario;
using AutoMapper;

namespace Api.Service.Test.Mapping
{
    public class EntityToRequestTestProfile : Profile
    {
        public EntityToRequestTestProfile()
        {
            CreateMap<UsuarioTestes, UserEntity>().ReverseMap();

            CreateMap<AtualizarDadosUsuarioRequest, UserEntity>().ReverseMap();
        }
    }
}
