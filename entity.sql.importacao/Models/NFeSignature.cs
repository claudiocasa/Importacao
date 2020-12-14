using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.sql.importacao.Models
{
   [Table("tb_nfe_signature")]
    public partial class NFeSignature
    {
        public int Id { get; set; }
        public string CanonicalizationMethod { get; set; }
        public string SignatureMethod { get; set; }
        public string Reference { get; set; }
        public string Transform1 { get; set; }
        public string Transform2 { get; set; }
        public string DigestMethod { get; set; }
        public string DigestValue { get; set; }
        public string SignatureValue { get; set; }
        public string X509certificate { get; set; }
        [ForeignKey("NotaFiscal")]
        public int NotaFiscalId { get; set; }
        public virtual NotaFiscal NotaFiscal { get; set; }
    }
}
