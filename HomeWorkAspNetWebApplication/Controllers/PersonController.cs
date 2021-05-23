using HomeWorkAspNetWebApplication.Domain.Interfaces;
using HomeWorkAspNetWebApplication.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HomeWorkAspNetWebApplication.Controllers
{
    [Route("persons/")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonManager _personManager;

        public PersonsController(IPersonManager personManager)
        {
            _personManager = personManager;
        }
        [HttpGet("search")]
        public IActionResult GetByFullName([FromQuery] string firstName, [FromQuery] string lastName)
        {
            var result = _personManager.GetByFullName(firstName, lastName);            
            if (result.Count != 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Нету персоны с таким ФИ");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _personManager.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Нету персоны с таким Id");
            }
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _personManager.GetAll();

            return Ok(result);
        }
        [HttpGet("pagination")]
        public IActionResult GetPagination([FromQuery] int skip, [FromQuery] int take)
        {
            var result = _personManager.GetPagination(skip, take);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Введенные данные не коректны, попробуйте другие числа");
            }
        }
        [HttpPost]
        public IActionResult Create([FromBody] PersonRequest request)
        {
            var result = _personManager.Create(request);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] PersonRequest request)
        {
            var result = _personManager.Update(request, id);
            if (result)
            {
                return Ok("Обновлено успешно");
            }
            else
            {
                return BadRequest("Такой персоны не существует");
            }
        }   
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
           var result = _personManager.Delete(id);
           if(result)
           {
                return Ok("Персона удалена");
           }
           else
           {
                return BadRequest("Id не найдено");
           }
        }

    }
}
