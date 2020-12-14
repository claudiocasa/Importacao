using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeImpIcmsRepositorio
    {
        List<NFeImpIcms> GetAllItems();
        NFeImpIcms Add(NFeImpIcms valor);
        NFeImpIcms GetById(int id);
        void Remove(int id);

    }
}
