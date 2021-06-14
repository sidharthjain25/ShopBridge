using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Implementation
{
    public class ApplicationRepository<T> : IApplicationRepository<T> where T : class,IBaseEntity
    {
        private DbContext _context;

        public ApplicationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>();
        }

        public T Get(long id)
        {
            return Get().SingleOrDefault(e => e.ID == id);
        }

        public int Create(T record)
        {
            _context.Add(record);
            return _context.SaveChanges();
        }

        public int Update(T record)
        {
            _context.Set<T>().Attach(record);
            _context.Entry(record).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var record = Get(id);

           
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
        #endregion
    }
}
