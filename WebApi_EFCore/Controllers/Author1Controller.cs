using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi_EFCore.Models;
using WebApi_EFCore.ViewModels;

namespace WebApi_EFCore.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    [Produces("application/json")]
    [Route("api/Author1")]
    public class Author1Controller : Controller
    {
        private ApplicationContext _context;

        public Author1Controller(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<AuthorViewModel> GetAll()
        {
            List<AuthorViewModel> authorList = new List<AuthorViewModel>();

            authorList = _context.Authors.Select(x => new AuthorViewModel
            {
                Name = $"{x.FirstName} {x.LastName}",
                Email = x.Email,
                BookList = x.Books.Where(a => a.Author.Id == x.Id).Select(b => new BookViewModel
                {
                    BookName = b.BookTitle,
                    Genre = b.Genre,
                    Publisher = b.Publisher,
                    Price = b.Price
                }).ToList()
            }).ToList();

            return authorList;
        }
    }
}