using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_EFCore.Models
{
    public class Book : BaseEntity
    {
        [Required(ErrorMessage = "Kitap başlığını giriniz.")]
        [StringLength(50, MinimumLength = 2)]
        public string BookTitle { get; set; }
        
        [Required(ErrorMessage = "Yayımcı ismini giriniz.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "2 ile 100 karakter arasında olmalı.")]
        public string Publisher { get; set; }

        public string Genre { get; set; }

        [Required(ErrorMessage = "Kitap fiyatını giriniz.")]
        [DataType(DataType.Currency)]
        [Range(1, 999, ErrorMessage = "1 ile 999 arasında bir değer giriniz.")]
        public float Price { get; set; }

        public Int64 AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
