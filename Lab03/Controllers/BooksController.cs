using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        Books BooksList = new Books();
        //post
        public void AddBook()
        {
        }

        //get id
        [HttpGet("{Id}")]
        public Book GetBookById(string Id)
        {
            var query = from book in BooksList.books where book.ID.Equals(int.Parse(Id)) select book;
            query.First();
            return query.First();
        }

        [HttpGet]
        public List<Book> GetAllBooks()
        {
            return BooksList.books;
        }

        //post
        public void UpdateBookById()
        {

        }
        //?post
        public void DeleteBookById()
        {

        }
    }
}