using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_inf_suplementar")]
    public partial class NFeInfSupl
    {
        public int Id { get; set; }
        public string QrCode { get; set; }
        public string UrlChave { get; set; }
        [ForeignKey("NotaFiscal")]
        public int NotaFiscalId { get; set; }
        public virtual NotaFiscal NotaFiscal { get; set; }
    }
}
