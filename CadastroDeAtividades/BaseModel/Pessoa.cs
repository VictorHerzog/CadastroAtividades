using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BaseModel
{
     public class Pessoa
    {
        [Key]
        public int PessoaID { get; set; }
        [Required]
        public string Nome { get; set; }

        public string Parentesco { get; set; }
        [Required]
        public bool Ativo { get; set; }
        
    }
}
