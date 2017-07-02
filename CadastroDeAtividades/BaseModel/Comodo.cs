using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModel
{
   public class Comodo
    {
        [Key]
        public int ComodoID { get; set; }
        [Required]
        public string NomeComodo { get; set; }
        
        public bool Ativo { get; set; }

    }
}
