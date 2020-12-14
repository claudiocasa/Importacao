using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeDetPagRepositorio
    {
        List<NFeDetPag> GetAllItems();
        NFeDetPag Add(NFeDetPag valor);
        NFeDetPag GetById(int id);
        void Remove(int id);
    }
}
