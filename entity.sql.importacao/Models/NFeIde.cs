using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_ide")]
    public partial class NFeIde
    {
        public int Id { get; set; }


        public string CUf { get; set; }

        public string CNf { get; set; }

        public string NatOp { get; set; }
 
        public string Mod { get; set; }
 
        public string Serie { get; set; }
 
        public string NNf { get; set; }
 
        public string DhEmi { get; set; }
 
        public string TpNf { get; set; }
 
        public string IdDest { get; set; }
 
        public string CMunFg { get; set; }
 
        public string TpImp { get; set; }
 
        public string TpEmis { get; set; }
 
        public string CDv { get; set; }
 
        public string TpAmb { get; set; }
 
        public string FinNfe { get; set; }
 
        public string IndFinal { get; set; }
 
        public string IndPres { get; set; }
 
        public string ProcEmi { get; set; }
 
        public string VerProc { get; set; }
        [ForeignKey("NotaFiscal")]
        public int NotaFiscalId { get; set; }
        public virtual NotaFiscal NotaFiscal { get; set; }
    }
}
