using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeImpPisNtRepositorio
    {

        List<NFeImpPisNt> GetAllItems();
        NFeImpPisNt Add(NFeImpPisNt valor);
        NFeImpPisNt GetById(int id);
        void Remove(int id);
      
    }
}
