using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeImpPisRepositorio
    {

        List<NFeImpPis> GetAllItems();
        NFeImpPis Add(NFeImpPis valor);
        NFeImpPis GetById(int id);
        void Remove(int id);
      
    }
}
