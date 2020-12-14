using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeDetItemRepositorio
    {
        List<NFeDetItem> GetAllItems(int id);
        NFeDetItem Add(NFeDetItem novoItem);
        NFeDetItem GetById(int id);
        void Remove(int id);
    }
}
