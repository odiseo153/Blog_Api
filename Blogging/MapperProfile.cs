using AutoMapper;
using Blogging.DTOS;
using Data.Modelos;

namespace Blogging
{
    public class MapperProfile :Profile
    {
        public MapperProfile() 
        {
            CreateMap<UsuarioCreateDTO, Usuario>();

            CreateMap<CrearPublicacionDTO, Publicacion>();

            CreateMap<CreateCommentDTO, Comment>();

        }  
    }
}
