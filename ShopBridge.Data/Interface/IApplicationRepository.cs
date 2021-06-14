using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
    public interface IApplicationRepository<T> : IDisposable
    {
        IQueryable<T> Get();

        T Get(long id);

        int Create(T record);

        int Update(T record);

        void Delete(long id);

        int Save();

        Task<int> SaveAsync();
    }
}
