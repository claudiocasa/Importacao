using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeIdeRepositorio
    {
        List<NFeIde> GetAllItems();
        NFeIde Add(NFeIde valor);
        NFeIde GetById(int id);
        void Remove(int id);
    }
}
