using Api.Domain.Entities;
using Api.Domain.Models;
using Api.Domain.Models.User;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToRequestProfile : Profile
    {
        public EntityToRequestProfile()
        {
            CreateMap<UserModel, UsuarioRequest>()
                .ReverseMap();

            CreateMap<UsuarioCreateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UsuarioUpdateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UsuarioRequest, UserEntity>()
            .ReverseMap();

            CreateMap<UsuarioResult, UserEntity>()
            .ReverseMap();

            CreateMap<CadastroUsuarioRequest, UserEntity>()
            .ReverseMap();

            CreateMap<AtualizarDadosUsuarioResult, UserEntity>()
           .ReverseMap();

            CreateMap<AtualizarDadosUsuarioRequest, UserEntity>()
            .ReverseMap();

            CreateMap<UserEntity, CadastroUsuarioRequest>()
            .ReverseMap();

            CreateMap<CadastroUsuarioResult, UserEntity>()
            .ReverseMap();

            CreateMap<DeletarUsuarioRequest, UserEntity>()
            .ReverseMap();

            CreateMap<DeletarUsuarioResult, UserEntity>()
            .ReverseMap();

            CreateMap<bool, DeletarUsuarioResult>()
            .ReverseMap();

            CreateMap<CadastroUsuarioRequest, UserEntity>()
            .ReverseMap();

        }
    }
}
