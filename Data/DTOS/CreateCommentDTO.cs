using System.ComponentModel.DataAnnotations;

namespace Blogging.DTOS
{
    public class CreateCommentDTO
    {
     
        public int? post_Id { get; set; }

    
        public string? Content { get; set; }
    }
}
