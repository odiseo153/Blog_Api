using Blogging.DTOS;
using Data.Modelos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Validation
{
    public class UsuarioValidation : AbstractValidator<UsuarioCreateDTO>
    {
        public UsuarioValidation()
        {
            RuleFor(x => x.Clave).NotNull().NotEmpty();
            RuleFor(x => x.Nombre).NotNull().NotEmpty();

        }  
    }
}
