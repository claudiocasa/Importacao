using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_imp_icms")]
    public partial class NFeImpIcms
    {
        public int Id { get; set; }
      
        public string Orig { get; set; }
        public string Csosn { get; set; }
        [ForeignKey("NFeDetItem")]
        public int NFeDetItemId { get; set; }
        public virtual NFeDetItem NFeDetItem { get; set; }

    }
}
