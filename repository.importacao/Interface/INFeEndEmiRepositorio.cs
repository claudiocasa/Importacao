using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeEndEmiRepositorio
    {
        List<NFeEndEmi> GetAllItems();
        NFeEndEmi Add(NFeEndEmi valor);
        NFeEndEmi GetById(int id);
        void Remove(int id);
     
    }
}
