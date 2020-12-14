using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_detalhe_pagamento")]
    public partial class NFeDetPag
    {
        public int Id { get; set; }
        public string IndPag { get; set; }
        public string TPag { get; set; }
        public string VPag { get; set; }
        public string TpIntegra { get; set; }

        [ForeignKey("NFePag")]
        public int NFePagId { get; set; }
        public virtual NFePag NFePag { get; set; }
    }
}
