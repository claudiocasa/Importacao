using entity.sql.importacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace repository.importacao.repository
{
    public class NFeDetPagRepositorio : IDisposable, INFeDetPagRepositorio
    {
        private EFContext _context;

        #region .: Construtor :.

        public NFeDetPagRepositorio(EFContext context)
        {
            _context = context;
        }

        #endregion

        #region .: Metodos :.

        public List<NFeDetPag> GetAllItems()
        {
            return _context.NFeDetPag.ToList();
        }

        public NFeDetPag Add(NFeDetPag valor)
        {
            _context.NFeDetPag.Add(valor);
            _context.SaveChanges();


            return valor;
        }

        public NFeDetPag GetById(int id)
        {
            return _context.NFeDetPag.Where(x => x.Id.Equals(id)).FirstOrDefault();
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
        ~NFeDetPagRepositorio()
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