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
        //post
        public void AddBook()
        {
        }

        //get id
        public string GetBookById()
        {
        }

        //get
        public List<Models.Book> GetAllBooks()
        {
        
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