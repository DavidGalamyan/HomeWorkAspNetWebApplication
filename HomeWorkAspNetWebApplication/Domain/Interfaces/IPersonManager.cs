using HomeWorkAspNetWebApplication.Models;
using HomeWorkAspNetWebApplication.Models.Dto;
using System.Collections.Generic;

namespace HomeWorkAspNetWebApplication.Domain.Interfaces
{
    public interface IPersonManager
    {
        public int Create(PersonRequest personRequest);
        public bool Update(PersonRequest personRequest, int id);
        public bool Delete(int id);
        public Person GetById(int id);
        public Person GetByFullName(string firstName, string lastName);
        public IEnumerable<Person> GetPagination(int skip, int take);
        public IEnumerable<Person> GetAll();
    }
}
