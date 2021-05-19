using HomeWorkAspNetWebApplication.Models;
using System.Collections.Generic;

namespace HomeWorkAspNetWebApplication.Data.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Person GetByFullName(string firstName, string lastName);
        IEnumerable<Person> GetByPagination(int skip,int take);
    }
}
