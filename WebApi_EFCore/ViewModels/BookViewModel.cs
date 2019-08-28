using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_EFCore.ViewModels
{
    public class BookViewModel
    {
        public string BookName { get; set; }

        public float Price { get; set; }

        public string Genre { get; set; }

        public string Publisher { get; set; }

    }
}
