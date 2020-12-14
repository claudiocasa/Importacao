using entity.sql.importacao.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace repository.importacao.repository
{
    public class NFeInfSuplRepositorio : IDisposable, INFeInfSuplRepositorio
    {
        private EFContext _context;

        #region .: Construtor :.

        public NFeInfSuplRepositorio(EFContext context)
        {
            _context = context;
        }

        #endregion

        #region .: Metodos :.

        public List<NFeInfSupl> GetAllItems()
        {
            return _context.NFeInfSupl.ToList();
        }

        public NFeInfSupl Add(NFeInfSupl valor)
        {
            _context.NFeInfSupl.Add(valor);
            _context.SaveChanges();

            return valor;
        }

        public NFeInfSupl GetById(int id)
        {
            return _context.NFeInfSupl.Where(x => x.Id.Equals(id)).FirstOrDefault();
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
        ~NFeInfSuplRepositorio()
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
