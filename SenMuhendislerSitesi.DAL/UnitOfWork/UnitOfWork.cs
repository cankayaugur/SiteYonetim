using SenMuhendislerSitesi.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationContext _context;
        public UnitOfWork()
        {
            _context = new ApplicationContext();
        }

        public ApplicationContext GetContext()
        {
            return _context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
