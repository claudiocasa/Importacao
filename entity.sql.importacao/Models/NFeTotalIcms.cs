using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_total_icms")]
    public partial class NFeTotalIcms
    {
        public int Id { get; set; }

        public string QrCode { get; set; }
        public string VBc { get; set; }
        public string VIcms { get; set; }
        public string VIcmsdeson { get; set; }
        public string VFcp { get; set; }
        public string VBcst { get; set; }
        public string VSt { get; set; }
        public string VFcpst { get; set; }
        public string VFcpstret { get; set; }
        public string VProd { get; set; }
        public string VFrete { get; set; }
        public string VSeg { get; set; }
        public string VDesc { get; set; }
        public string VIi { get; set; }
        public string VIpi { get; set; }
        public string VIpidevol { get; set; }
        public string VPis { get; set; }
        public string VCofins { get; set; }
        public string VOutro { get; set; }
        public string VNf { get; set; }
        public string VTotTrib { get; set; }
        [ForeignKey("NotaFiscal")]
        public int NotaFiscalId { get; set; }

        public virtual NotaFiscal NotaFiscal { get; set; }
    }
}
