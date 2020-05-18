using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Lab03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public void AddBook()
        {
        }

        public string GetBookById()
        {
        }

        public List<Models.Book> GetAllBooks()
        {
        
        }

        public void UpdateBookById()
        {

        }

        public void DeleteBookById()
        {

        }
    }
}