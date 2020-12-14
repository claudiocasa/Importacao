using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_imp_cofins")]
    public partial class NFeImpCofins
    {
       
        public int Id { get; set; }
        [ForeignKey("NFeDetItem")]
        public int NFeDetItemId { get; set; }
        public virtual NFeDetItem NFeDetItem { get; set; }
       
    }
}
