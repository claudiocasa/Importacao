﻿using entity.sql.importacao.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace repository.importacao.repository
{
    public class NFeDetItemRepositorio : IDisposable, INFeDetItemRepositorio
    {
        private EFContext _context;

        #region .: Construtor :.

        public NFeDetItemRepositorio(EFContext context)
        {
            _context = context;
        }

        #endregion

        #region .: Metodos :.

        public List<NFeDetItem> GetAllItems(int id)
        {
            return _context.NFeDetItem.Where(x => x.NotaFiscalId.Equals(id)).ToList();
        }

        public NFeDetItem Add(NFeDetItem valor)
        {
            _context.NFeDetItem.Add(valor);
            _context.SaveChanges();


            return valor;
        }

        public NFeDetItem GetById(int id)
        {
            return _context.NFeDetItem.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region .: Disposed :.

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)
                }

                // Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
                // Tarefa pendente: definir campos grandes como nulos
                disposedValue = true;
            }
        }

        // // Tarefa pendente: substituir o finalizador somente se 'Dispose(bool disposing)' tiver o código para liberar recursos não gerenciados
        ~NFeDetItemRepositorio()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

       
        #endregion

    }
}
