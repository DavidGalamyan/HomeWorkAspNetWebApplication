using System.Collections.Generic;

namespace HomeWorkAspNetWebApplication.Data
{
    public interface IBaseRepository<T>
    {
        T GetItem(int id);
        IEnumerable<T> GetItems();
        int Add(T item);
        bool Update(T item);
        bool Delete(int id);
    }
}
