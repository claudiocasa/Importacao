using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_transportadora")]
    public partial class NFeTransp
    {
        public int Id { get; set; }
        public string modFrete { get; set; }

        [ForeignKey("NotaFiscal")]
        public int NotaFiscalId { get; set; }
        public virtual NotaFiscal NotaFiscal { get; set; }
    }
}
