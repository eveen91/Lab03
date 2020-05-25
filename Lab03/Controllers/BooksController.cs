using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab03.Models;
using Lab03.Set;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        Books BooksList = new Books();

        [HttpPost]
        public IActionResult AddBook([FromBody] Book GivenBook)
        {
            if (GivenBook.Author != "" && GivenBook.ID != 0 && GivenBook.Title != "")
            {
                if (BooksList.books.Find(x => x.ID == GivenBook.ID) == null)
                {
                    try
                    {
                        BooksList.AddBook(GivenBook);
                        return StatusCode(200, "Ok");
                    }
                    catch
                    {
                        return StatusCode(400, "Bad Request");
                    }
                }
                else
                {
                    return StatusCode(409, "Conflict, user with this id exist");
                }
            }
            else
            {
                return StatusCode(400, "Bad Request");
            }
        }

        //get id
        [HttpGet("{Id}")]
        [Authorize]
        public Book GetBookById(string Id)
        {
            var query = from book in BooksList.books where book.ID.Equals(int.Parse(Id)) select book;
            query.First();
            return query.First();
        }

        [HttpGet]
        [Authorize]
        public List<Book> GetAllBooks()
        {
            return BooksList.books;
        }

        
        [HttpPut("{Id}")]
        public IActionResult UpdateBookById(string id,[FromBody] Book GivenBook)
        {
            var book = BooksList.books.Find(x => x.ID == int.Parse(id));
            if (book == null)
            {
                return StatusCode(400, "Bad Request");
            }
            else
            {
                BooksList.UpdateBook(id, GivenBook);
                return StatusCode(200, "ok");
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteBookById(string id)
        {
            var book = BooksList.books.Find(x => x.ID == int.Parse(id));
            if (book == null)
            {
                return StatusCode(400, "nope");
            }
            else
            {
                BooksList.RemoveBook(id);
                return StatusCode(200, "ok");
            }
        }
    }
}