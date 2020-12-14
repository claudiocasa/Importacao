using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_emitente")]
    public partial class NFeEmi
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string XNome { get; set; }
        public string XFant { get; set; }
        public string Ie { get; set; }
        public string Crt { get; set; }
        [ForeignKey("NotaFiscal")]
        public int NotaFiscalId { get; set; }
        public virtual NotaFiscal NotaFiscal { get; set; }
    }
}
