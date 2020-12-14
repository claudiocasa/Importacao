using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeImpCofinsNtRepositorio
    {

        List<NFeImpCofinsNt> GetAllItems();
        NFeImpCofinsNt Add(NFeImpCofinsNt valor);
        NFeImpCofinsNt GetById(int id);
        void Remove(int id);

    }
}
