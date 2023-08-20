using AutoMapper;
using Blogging.DTOS;
using Blogging.Token;
using Data.Modelos;
using Data.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Azure.Core;
using Data.Validation;
using Xunit;
using Xunit.Sdk;

namespace Blogging.Controllers
{
    public class UserController : Controller
    {
        private BloggingContext context;
        IMapper mapper;
        public UserController(BloggingContext con,IMapper map) 
        {
        context = con;
        mapper = map;

            context.Usuarios.Add(Data.AgregarDatos());
        }


        [HttpPost("auth/register")]
        public ActionResult RegistrarUser(UsuarioCreateDTO user)
        {

            var usuario = mapper.Map<Usuario>(user); 

            context.Usuarios.Add(usuario);
            context.SaveChanges();
            
            return StatusCode(StatusCodes.Status200OK,usuario);
        }

        [HttpPost("auth/Login")]
        public ActionResult LoginUser([Required]UsuarioCreateDTO user)
        {

            var usuario = context.Usuarios.Select(x=>x.Nombre==user.Nombre && x.Clave == user.Clave);

            if(usuario == null) 
            { 
             return StatusCode(StatusCodes.Status403Forbidden,"Nombre o contraseña incorrectos");
            }

            return StatusCode(StatusCodes.Status200OK,new {Token=TokenController.GenerarToken(user)} );
        }


        [HttpPost("post")]
        public ActionResult CrearPublicacion(CrearPublicacionDTO publish)
        {
            var publicacion= mapper.Map<Publicacion>(publish);

            context.Publicaciones.Add(publicacion);
            context.SaveChanges();

            return StatusCode(StatusCodes.Status200OK,publicacion);
        }

        [HttpGet("post/:id")]
        public ActionResult GetPublishById(int id)
        {
            var publicacion = context.Publicaciones.FirstOrDefault(x=>x.Id==id);

            return StatusCode(StatusCodes.Status200OK, publicacion);
        }

        [Authorize]
        [HttpGet("Publicaciones")]
        public ActionResult GetPublish()
        {
            return StatusCode(StatusCodes.Status200OK, context.Publicaciones.ToList());
        }

        [HttpGet("User")]
        public ActionResult GetUser()
        {
            return StatusCode(StatusCodes.Status200OK, context.Usuarios.ToList());
        }

        [HttpGet("Busqueda")]
        public ActionResult Search([Required]string busqueda)
        {
            var result = context.Publicaciones.Where(x => x.Titulo.Contains(busqueda) || x.Content.Contains(busqueda));

            return StatusCode(StatusCodes.Status200OK, result.ToList());
        }




        [HttpPost("Comments")]
        public dynamic CreateComment(CreateCommentDTO comment)
        {
            var validation = new CommentValidation().Validate(comment);

            if (!validation.IsValid) 
            {
                return validation.Errors.Select(x=>new
                {
                    Message=x.ErrorMessage,
                    Code=x.ErrorCode

                });     
            }

            var NewComment = mapper.Map<Comment>(comment);


            context.comment.Add(NewComment);
            context.SaveChanges();


         return StatusCode(StatusCodes.Status200OK, comment);
        }

        
    }
}
