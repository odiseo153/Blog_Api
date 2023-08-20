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
    public class CommentValidation : AbstractValidator<CreateCommentDTO>
    {
        public CommentValidation() 
        {
            RuleFor(x => x.Content).NotEmpty().NotNull();
            RuleFor(x => x.post_Id).NotEmpty().NotNull();
        }
    }
}
