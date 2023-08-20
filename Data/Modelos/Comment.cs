using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Modelos
{
     public class Comment
    {
        public int id { get; set; }
        public int post_Id { get; set; }

        public string Content { get; set;}
    }
}
