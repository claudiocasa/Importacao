using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_imp_pis_nt")]
    public partial class NFeImpPisNt
    {
        public int Id { get; set; }
        public string Cst { get; set; }
        [ForeignKey("NFeImpPis")]
        public int NFeImpPisId { get; set; }
        public virtual NFeImpPis NFeImpPis { get; set; }
    }
}
