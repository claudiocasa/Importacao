using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeImpCofinsRepositorio
    {

        List<NFeImpCofins> GetAllItems();
        NFeImpCofins Add(NFeImpCofins valor);
        NFeImpCofins GetById(int id);
        void Remove(int id);

    }
}
