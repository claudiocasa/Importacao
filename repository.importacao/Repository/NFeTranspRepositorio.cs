

using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace repository.importacao.repository
{
    public class NFeTranspRepositorio : IDisposable, INFeTranspRepositorio
    {
        private EFContext _context;

        #region .: Construtor :.

        public NFeTranspRepositorio(EFContext context)
        {
            _context = context;
        }

        #endregion

        #region .: Metodos :.

        public List<NFeTransp> GetAllItems()
        {
            return _context.NFeTransp.ToList();
        }

        public NFeTransp Add(NFeTransp valor)
        {
            _context.NFeTransp.Add(valor);
            _context.SaveChanges();


            return valor;
        }

        public NFeTransp GetById(int id)
        {
            return _context.NFeTransp.Where(x => x.Id.Equals(id)).FirstOrDefault();
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
        ~NFeTranspRepositorio()
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