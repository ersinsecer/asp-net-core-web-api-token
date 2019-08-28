using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_EFCore.Models;
using WebApi_EFCore.Repositories;

namespace WebApi_EFCore.Controllers
{
    
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private IRepository<Author> _authorRepository;

        public AuthorController(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IEnumerable<Author> GetAll()
        {
            var authors = _authorRepository.GetAll();
            return authors;
        }

        [HttpGet("{id}")]
        public Author Get(int id)
        {
            var books = _authorRepository.Get(id);
            return books;
        }

        [HttpPost]
        public void Post([FromBody] Author author)
        {
            _authorRepository.Insert(author);
        }

        [HttpPut]
        public void Put([FromBody] Author author)
        {
            _authorRepository.Update(author);
        }
    }
}