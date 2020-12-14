using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeTranspRepositorio
    {
        List<NFeTransp> GetAllItems();
        NFeTransp Add(NFeTransp valor);
        NFeTransp GetById(int id);
        void Remove(int id);
    }
}
