using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library.Repository;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IRepository<Book> db;


        [HttpPost]
        public ActionResult Create (Book book)
        {
            if (ModelState.IsValid)
            {
                db.Create(book);
                db.Save();
            }
            return new JsonResult(book);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            IEnumerable<Book> listBooks = db.GetAll();
            return new JsonResult(listBooks);
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            var book = db.Get(id);
            return new JsonResult(book);
        }

        [HttpPost]
        public ActionResult Update(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Update(book);
                db.Save();
            }
            return new JsonResult(book);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            db.Delete(id);
            return new OkResult();
        }

        [HttpGet]
        public ActionResult<Book> SerchBook(string nameBook)
        {
            return  db.GetAll().FirstOrDefault(p => p.Name.Contains(nameBook));
            
        }

        [HttpGet]
        public ActionResult <IEnumerable<IssuanceOfBook>> GetIssuedBooks()
        {
            LibraryDbContext context = new LibraryDbContext();

            return context.IssuanceOfBooks.ToList();
        }
        
    }
}
