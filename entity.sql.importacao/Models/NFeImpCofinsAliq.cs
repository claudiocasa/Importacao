using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_imp_cofins_aliq")]
    public partial class NFeImpCofinsAliq
    {
        public int Id { get; set; }
       
        public string Cst { get; set; }
        public string VBc { get; set; }
        public string PCofins { get; set; }
        public string VCofins { get; set; }
        [ForeignKey("NFeImpCofins")]
        public int NFeImpCofinsId { get; set; }
        public virtual NFeImpCofins ImpCofins { get; set; }


    }
}
