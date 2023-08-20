using System.ComponentModel.DataAnnotations;

namespace Blogging.DTOS
{
    public class CrearPublicacionDTO
    {
        [Required]
        public string? Titulo { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public int? UsuarioId { get; set; }
    }
}
