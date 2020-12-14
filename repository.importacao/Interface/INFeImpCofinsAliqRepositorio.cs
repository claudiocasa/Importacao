using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeImpCofinsAliqRepositorio
    {

        List<NFeImpCofinsAliq> GetAllItems();
        NFeImpCofinsAliq Add(NFeImpCofinsAliq valor);
        NFeImpCofinsAliq GetById(int id);
        void Remove(int id);

    }
}
