using AutoMapper;
using Blogging.DTOS;
using Data.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Blogging.Controllers
{
    public class PublicacionesController : Controller
    {

        private BloggingContext context;
        IMapper mapper;
        public PublicacionesController(BloggingContext con, IMapper map)
        {
            context = con;
            mapper = map;
          
        }

    
    
        [HttpGet("Publicaciones")]
        public ActionResult GetPublish()
        {

         

            return StatusCode(StatusCodes.Status200OK, context.Publicaciones.ToList());
        }

        [HttpGet("Busqueda_De_Publicacion")]
        public ActionResult Search([Required] string busqueda)
        {
            var result = context.Publicaciones.Where(x => x.Titulo.Contains(busqueda) || x.Content.Contains(busqueda));

            return StatusCode(StatusCodes.Status200OK, result.ToList());
        }

        [HttpGet("PublicacionById/:id")]
        public ActionResult GetPublishById([Required]int id)
        {
            var publicacion = context.Publicaciones.FirstOrDefault(x => x.Id == id);
            return StatusCode(StatusCodes.Status200OK, publicacion);
        }

        [HttpPost("Agregar_Publicacion")]
        public ActionResult CrearPublicacion([Required]CrearPublicacionDTO publish)
        {

            var publicacion = mapper.Map<Publicacion>(publish);

            context.Publicaciones.AddAsync(publicacion);
            context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, publish);
        }

 
        [HttpDelete("Borrar_Publicacion")]
        public ActionResult Delete([Required] int id)
        {
            var publicacion = context.Publicaciones.FirstOrDefault(x => x.Id == id);

            if(publicacion == null)
            {
                return StatusCode(StatusCodes.Status200OK, $"No se encontro la Publicacion con este {id} ID");
            }

            context.Publicaciones.Remove(publicacion);
            context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, publicacion);
        }

        [HttpPut("Actualizar_Publicacion")]
        public ActionResult Put([Required]int id,[Required]CrearPublicacionDTO publish)
        {
            var publicacion = context.Publicaciones.Where(x=> x.Id==id).FirstOrDefault();

            if (publicacion == null) 
            {
                return StatusCode(StatusCodes.Status404NotFound, $"No se encontro una Publicacion con este ID {id}");
            }

            publicacion.Titulo = publish.Titulo;
            publicacion.Content = publish.Content;
            publicacion.UsuarioId = publish.UsuarioId;

            context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, publicacion);
        }


    }
}
