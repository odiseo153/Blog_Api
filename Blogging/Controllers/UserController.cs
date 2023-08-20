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

       }

       

        [HttpGet("Obtener_Usuario")]
        public ActionResult GetUser()
        {
           return StatusCode(StatusCodes.Status200OK, context.Usuarios.ToList());
        }

        [HttpPost("Registrar_Usuario")]
        public ActionResult RegistrarUser([Required]UsuarioCreateDTO user)
        {

            var usuario = mapper.Map<Usuario>(user); 

            context.Usuarios.Add(usuario);
            context.SaveChanges();
            
            return StatusCode(StatusCodes.Status200OK,usuario);
        }

        [HttpGet("Iniciar_Sesion")]
        public ActionResult LoginUser([Required]UsuarioCreateDTO user)
        {

            var usuario = context.Usuarios.Select(x=>x.Nombre==user.Nombre && x.Clave == user.Clave);

            if(usuario == null) 
            { 
             return StatusCode(StatusCodes.Status403Forbidden,"Nombre o contraseña incorrectos");
            }

            return StatusCode(StatusCodes.Status200OK,new {Token=TokenController.GenerarToken(user)} );
        }

      

      

      
    }
}
