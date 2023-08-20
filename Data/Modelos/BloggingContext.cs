using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.Modelos;

public partial class BloggingContext : DbContext
{
    public BloggingContext()
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder op)
    {

        op.UseInMemoryDatabase("DbOdiseo");
    }


    public virtual DbSet<Publicacion> Publicaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Comment> comment { get; set; }




}
