using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_det_item")]
    public partial class NFeDetItem
    {
        public int Id { get; set; }
        public string CProd { get; set; }
        public string CEan { get; set; }
        public string XProd { get; set; }
        public string Ncm { get; set; }
        public string Cest { get; set; }
        public string IndEscala { get; set; }
        public string Cfop { get; set; }
        public string UCom { get; set; }
        public string QCom { get; set; }
        public string VUnCom { get; set; }
        public string VProd { get; set; }
        public string CEantrib { get; set; }
        public string UTrib { get; set; }
        public string QTrib { get; set; }
        public string VUnTrib { get; set; }
        public string IndTot { get; set; }
        public string VTotTrib { get; set; }
        [ForeignKey("NotaFiscal")]
        public int NotaFiscalId { get; set; }

        public virtual NotaFiscal NotaFiscal { get; set; }
       
    }
}
