using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeImpPisAliqRepositorio
    {

        List<NFeImpPisAliq> GetAllItems();
        NFeImpPisAliq Add(NFeImpPisAliq valor);
        NFeImpPisAliq GetById(int id);
        void Remove(int id);
      
    }
}
