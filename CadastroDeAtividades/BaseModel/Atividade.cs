﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseModel
{
    public class Atividade
    {
        [Key]
        public int AtividadeID { get; set; }

        [Required] 
        public string NomeAtividade { get; set; }

        public string DescricaoAtividade { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [ForeignKey("_Comodo")]
        public int ComodoID { get; set; }

        public Comodo _Comodo { get; set; }

        [ForeignKey("_Pessoa")]
        public int PessoaID { get; set; }
        
        public Pessoa _Pessoa { get; set; }


    }
}
