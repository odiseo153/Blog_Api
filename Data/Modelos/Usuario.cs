using AutoMapper;
using Blogging.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Data.Modelos;

public partial class Usuario
{
    private static BloggingContext context = new BloggingContext();

    
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Clave { get; set; }

    public virtual ICollection<Publicacion> Publicaciones { get; set; } = new List<Publicacion>();



}
