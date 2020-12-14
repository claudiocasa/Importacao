using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_imp_pis")]
    public partial class NFeImpPis
    {
        public int Id { get; set; }
      
        [ForeignKey("NFeDetItem")]
        public int NFeDetItemId { get; set; }

        public virtual NFeDetItem NFeDetItem { get; set; }

    }
}
