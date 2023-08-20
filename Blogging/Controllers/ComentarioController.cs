using AutoMapper;
using Blogging.DTOS;
using Data.Modelos;
using Data.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Blogging.Controllers
{
    public class ComentarioController : Controller
    {

        private BloggingContext context;
        IMapper mapper;
        public ComentarioController(BloggingContext con, IMapper map)
        {
            context = con;
            mapper = map;


        }

        [HttpGet("Obtener_Commentarios")]
        public dynamic GetComentario()
        {
            return StatusCode(StatusCodes.Status200OK, context.comment.ToList());
        }


        [HttpPost("Agregar_Commentarios")]
        public dynamic CreateComment(CreateCommentDTO comment)
        {
            var validation = new CommentValidation().Validate(comment);

            if (!validation.IsValid)
            {
                return validation.Errors.Select(x => new
                {
                    Message = x.ErrorMessage,
                    Code = x.ErrorCode

                });
            }

            var NewComment = mapper.Map<Comment>(comment);


            context.comment.Add(NewComment);
            context.SaveChanges();


            return StatusCode(StatusCodes.Status200OK, comment);
        }
    }
}
