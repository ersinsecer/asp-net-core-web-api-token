using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_EFCore.Models;

namespace WebApi_EFCore.Repositories
{
    public interface IDataAccess<TEntity,U> where TEntity : class
    {
        IEnumerable<TEntity> GetBooks();
        TEntity GetBook(U id);
        int AddBook(TEntity book);
        int UpdateBook(TEntity book, U id);
        int DeleteBook(U id);
    }
    public class DataAccessRepository : IDataAccess<Book,int>
    {
        ApplicationContext _ctx;
        public DataAccessRepository(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Book> GetBooks()
        {
            var books = _ctx.Books.ToList();
            return books;
        }

        public Book GetBook(int id)
        {
            var book = _ctx.Books.FirstOrDefault(x => x.Id == id);
            return book;
        }

        public int AddBook(Book book)
        {
            _ctx.Books.Add(book);
            int res = _ctx.SaveChanges();
            return res;
        }

        public int UpdateBook(Book b, int id)
        {
            int res = 0;
            var book = _ctx.Books.Find(id);
            if (book!=null)
            {
                book.BookTitle = b.BookTitle;
                book.AuthorName = b.AuthorName;
                book.Publisher = b.Publisher;
                book.Genre = b.Genre;
                book.Price = b.Price;
                res = _ctx.SaveChanges();
            }
            return res;
        }

        public int DeleteBook(int id)
        {
            int res = 0;
            var book = _ctx.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _ctx.Books.Remove(book);
                res = _ctx.SaveChanges();
            }
            return res;
        }
    }
}
