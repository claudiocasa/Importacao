using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nota_fiscal")]
    public partial class NotaFiscal
    {
        public NotaFiscal()
        {
            NFeDetItem = new HashSet<NFeDetItem>();
        }

        public int Id { get; set; }
        
        public string InfNfe { get; set; }

        public string Versao { get; set; }
        public virtual ICollection<NFeDetItem> NFeDetItem { get; set; }

    }
}
