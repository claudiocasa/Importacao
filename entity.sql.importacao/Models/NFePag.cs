using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_pagamento")]
    public partial class NFePag
    {
        public int Id { get; set; }
        public string VTroco { get; set; }

        [ForeignKey("NotaFiscal")]
        public int NotaFiscalId { get; set; }
        public virtual NotaFiscal NotaFiscal { get; set; }
    }
}
