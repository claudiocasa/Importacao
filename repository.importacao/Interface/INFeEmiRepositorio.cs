using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeEmiRepositorio
    {
        List<NFeEmi> GetAllItems();
        NFeEmi Add(NFeEmi valor);
        NFeEmi GetById(int id);
        void Remove(int id);
     
    }
}
