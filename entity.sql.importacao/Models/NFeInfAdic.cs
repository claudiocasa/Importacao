using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_inf_adicional")]
    public partial class NFeInfAdic
    {
        public int Id { get; set; }
      
        public string InfAdFisco { get; set; }
        public string InfCpl { get; set; }

        [ForeignKey("NotaFiscal")]
        public int NotaFiscalId { get; set; }

        public virtual NotaFiscal NotaFiscal { get; set; }

    }
}
