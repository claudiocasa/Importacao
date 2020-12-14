using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INotaFiscalRepositorio
    {
        List<NotaFiscal> GetAllItems();
        NotaFiscal Add(NotaFiscal valor);
        NotaFiscal GetById(int id);
        NotaFiscal GetByNFe(string chave);
        void Remove(int id);
    }
}
