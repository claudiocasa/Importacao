using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeTotalIcmsRepositorio
    {
        List<NFeTotalIcms> GetAllItems();
        NFeTotalIcms Add(NFeTotalIcms valor);
        NFeTotalIcms GetById(int id);
        void Remove(int id);
    }
}
