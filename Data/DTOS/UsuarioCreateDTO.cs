using System.ComponentModel.DataAnnotations;

namespace Blogging.DTOS
{
    public class UsuarioCreateDTO
    {
        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Clave { get; set; }

    }
}
