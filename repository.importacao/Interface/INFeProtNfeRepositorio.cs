using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeProtNfeRepositorio
    {
        List<NFeProtNfe> GetAllItems();
        NFeProtNfe Add(NFeProtNfe valor);
        NFeProtNfe GetById(int id);
        void Remove(int id);
               
    }
}
