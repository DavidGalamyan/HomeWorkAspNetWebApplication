using HomeWorkAspNetWebApplication.Models;
using System.Collections.Generic;

namespace HomeWorkAspNetWebApplication.Data.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        List<Person> GetByFullName(string firstName, string lastName);
        IEnumerable<Person> GetByPagination(int skip,int take);
    }
}
