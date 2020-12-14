using entity.sql.importacao.Models;
using System.Collections.Generic;

namespace repository.importacao.repository
{
    public interface INFeInfSuplRepositorio
    {

        List<NFeInfSupl> GetAllItems();
        NFeInfSupl Add(NFeInfSupl valor);
        NFeInfSupl GetById(int id);
        void Remove(int id);


    }
}