using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeInfAdicRepositorio
    {

        List<NFeInfAdic> GetAllItems();
        NFeInfAdic Add(NFeInfAdic valor);
        NFeInfAdic GetById(int id);
        void Remove(int id);

      
    }
}
