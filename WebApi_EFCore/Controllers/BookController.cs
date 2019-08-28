using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi_EFCore.Models;
using WebApi_EFCore.Repositories;

namespace WebApi_EFCore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        IRepository<Book> _bookRepository;

        public BookController(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            var books = _bookRepository.GetAll();
            return books;
        }


        [HttpGet("{id}")]
        public Book Get(int id)

        {
            var books = _bookRepository.Get(id);
            return books;
        }

        [HttpPost]
        //[Route("addbook")]
        public void Post([FromBody] Book book)
        {
            _bookRepository.Insert(book);
        }


        [HttpPut]
        public void Put([FromBody] Book book)
        {
            _bookRepository.Update(book);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Book book = _bookRepository.Get(id);
            if (book != null)
            {
                _bookRepository.Delete(book);
            }
        }
    }
}