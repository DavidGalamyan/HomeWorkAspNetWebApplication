using HomeWorkAspNetWebApplication.Data.Interfaces;
using HomeWorkAspNetWebApplication.Domain.Interfaces;
using HomeWorkAspNetWebApplication.Models;
using HomeWorkAspNetWebApplication.Models.Dto;
using System.Collections.Generic;

namespace HomeWorkAspNetWebApplication.Domain.Inplementation
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository _personRepository;
        public PersonManager(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public int Create(PersonRequest personRequest)
        {
            var person = new Person()
            {
                Age = personRequest.Age,
                Company = personRequest.Company,
                Email = personRequest.Email,
                FirstName = personRequest.FirstName,
                LastName = personRequest.LastName,
                Id = 0
            };            
            var result = _personRepository.Add(person);
            return result;
        }

        public bool Delete(int id)
        {
            var result = _personRepository.Delete(id);
            return result;
        }

        public IEnumerable<Person> GetAll()
        {
            var result = _personRepository.GetItems();
            return result;
        }

        public List<Person> GetByFullName(string firstName, string lastName)
        {
            var result = _personRepository.GetByFullName(firstName, lastName);            
            return result;
        }

        public Person GetById(int id)
        {
            var result = _personRepository.GetItem(id);
            return result;
        }

        public IEnumerable<Person> GetPagination(int skip, int take)
        {
            var result = _personRepository.GetByPagination(skip, take);
            return result;
        }

        public bool Update(PersonRequest personRequest,int id)
        {
            var person = new Person()
            {
                Id = id,
                Age = personRequest.Age,
                Company = personRequest.Company,
                FirstName = personRequest.FirstName,
                LastName = personRequest.LastName,
                Email = personRequest.Email
            };
            var result = _personRepository.Update(person);
            return result;
        }
    }
}
