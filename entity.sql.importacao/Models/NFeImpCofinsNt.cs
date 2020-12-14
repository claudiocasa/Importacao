using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_imp_cofins_nt")]
    public partial class NFeImpCofinsNt
    {
        public int Id { get; set; }
      
        public string Cst { get; set; }
        [ForeignKey("NFeImpCofins")]
        public int NFeImpCofinsId { get; set; }
        public virtual NFeImpCofins ImpCofins { get; set; }
    }
}
