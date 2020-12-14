using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeSuplRepositorio
    {
        List<NFeInfSupl> GetAllItems();
        NFeInfSupl Add(NFeInfSupl valor);
        NFeInfSupl GetById(int id);
        void Remove(int id);
      
    }
}
