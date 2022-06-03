using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppMvcNHibernate.Repository
{
    public interface IRepository<T>
    {
        Task Add(T item);
        Task Remove(long id);
        Task Update(T item);
        Task<T> FindByID(long id);
        IEnumerable<T> FindAll();
    }
}
