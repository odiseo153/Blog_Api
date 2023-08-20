using Blogging.DTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Validation
{
   public class PublicacionValidation : AbstractValidator<CrearPublicacionDTO>
    {
        public PublicacionValidation() 
        {
            RuleFor(x => x.Titulo).NotEmpty().NotNull();
            RuleFor(x => x.Content).NotEmpty().NotNull();
        }
    }
}
