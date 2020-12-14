using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using entity.sql.importacao.Models;
using leitura.nfe.importacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repository.importacao.repository;

namespace api.importacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaFiscalController : ControllerBase
    {
        private EFContext _context;
        private string xml = string.Empty;
        public NotaFiscalController(EFContext context)
        {
            _context = context;
        }



        [Route("obter/{nfe}")]
        [HttpGet]
        public String Obter(string nfe)
        {

            try
            {
                using (NotaFiscalRepositorio obj = new NotaFiscalRepositorio(_context))
                {
                    NotaFiscal objNota = obj.GetByNFe(nfe);

                    using (Exportar objExportar = new Exportar(_context))
                    {
                         xml = objExportar.ObterXmlNFe(objNota.Id);
                    }
                }

            }
            catch (Exception e)
            {
            }

            return xml;
        }
    }
}
