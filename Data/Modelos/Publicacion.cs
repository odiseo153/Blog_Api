using System;
using System.Collections.Generic;

namespace Data.Modelos;

public partial class Publicacion
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Content { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
