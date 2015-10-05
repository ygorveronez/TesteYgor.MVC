using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteYgor.Domain.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        ICollection<T> SelectEntities();
        T SelectEntity(int id);
        void InsertEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
    }
}
