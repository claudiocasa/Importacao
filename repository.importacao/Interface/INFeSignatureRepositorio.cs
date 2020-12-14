using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.importacao.repository
{
    public interface INFeSignatureRepositorio
    {

        List<NFeSignature> GetAllItems();
        NFeSignature Add(NFeSignature valor);
        NFeSignature GetById(int id);
        void Remove(int id);

     
    }
}
