using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_EFCore.Models;

namespace WebApi_EFCore.ViewModels
{
    public class AuthorViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public List<BookViewModel> BookList { get; set; }

    }
}
