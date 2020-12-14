using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_end_emitente")]
    public partial class NFeEndEmi
    {
        public int Id { get; set; }
        public string XLgr { get; set; }
        public string Nro { get; set; }
        public string XCpl { get; set; }
        public string XBairro { get; set; }
        public string CMun { get; set; }
        public string XMun { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        [ForeignKey("NFeEmi")]
        public int NFeEmiId { get; set; }
        public virtual NFeEmi NFeEmi { get; set; }

    }
}
