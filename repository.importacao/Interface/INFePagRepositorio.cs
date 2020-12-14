using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFePagRepositorio
    {
        List<NFePag> GetAllItems();
        NFePag Add(NFePag valor);
        NFePag GetById(int id);
        void Remove(int id);
    }
}
