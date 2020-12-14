using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_protocolo_nfe")]
    public partial class NFeProtNfe
    {
        public int Id { get; set; }
        public string TpAmb { get; set; }
        public string VerAplic { get; set; }
        public string ChNfe { get; set; }
        public string DhRecbto { get; set; }
        public string NProt { get; set; }
        public string DigVal { get; set; }
        public string CStat { get; set; }
        public string XMotivo { get; set; }
        [ForeignKey("NotaFiscal")]
        public int NotaFiscalId { get; set; }

        public virtual NotaFiscal NotaFiscal { get; set; }
    }
}
