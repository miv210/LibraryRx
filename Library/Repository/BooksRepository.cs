using Library.Models;
using Microsoft.EntityFrameworkCore;


namespace Library.Repository
{
    public class BooksRepository : IRepository<Book>
    {
        LibraryDbContext context;

        public BooksRepository(LibraryDbContext Context)
        {
            context = Context;
        }

        public IEnumerable<Book> GetAll()
        {
            return context.Books;
        }

        public Book Get(int id)
        {
            return context.Books.FirstOrDefault(p => p.Id == id);
        }

        public void Create(Book book)
        {
            context.Books.Add(book);
        }

        public void Update(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Book book = context.Books.FirstOrDefault(p=> p.Id == id);
            if (book != null)
                context.Books.Remove(book);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
