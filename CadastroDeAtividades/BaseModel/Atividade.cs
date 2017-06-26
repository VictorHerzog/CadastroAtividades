using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace BaseModel
{
    class Atividade
    {
        public int AtividadeID { get; set; }

        [Required] 
        public string NomeAtividade { get; set; }

        public string DescricaoAtividade { get; set; }

        [Required]
        public bool Ativo { get; set; }

    }
}
