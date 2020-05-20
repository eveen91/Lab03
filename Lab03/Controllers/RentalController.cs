using System;
using Lab03.Models;
using System.Collections.Generic;
using System.Linq;
using Lab03.Set;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        Books BooksList = new Books();
        Users UsersList = new Users();
        LibraryHistory libraryHistory = new LibraryHistory();

        //Method:GET
        //URI:https://localhost:44326/api/Rental/BookRentedByUsers/3
        //userzy który wyporzyczyli daną książkę
        [HttpGet("BookRentedByUsers/{Id}")]
        public List<User> BookRentedByUser(string Id)
        {
            List<User> LendersList = new List<User>();
            var ListOfUsers = libraryHistory.GetUsersThatRentedBookWithId(int.Parse(Id));
            foreach (var User in ListOfUsers)
            {
                LendersList.Add(UsersList.users.Find(x => x.ID == User));
            }
            return LendersList;
        }

        //Method:GET
        //URI:https://localhost:44326/api/Rental/UserHistoryRent/3
        //książki wyporzyczone prze usera o id
        [HttpGet("UserHistoryRent/{Id}")]
        public List<Book> UserHistoryRent(string Id)
        {
            var ListOfRentedBooks = libraryHistory.GetBooksRentedByUser(int.Parse(Id));
            List<Book> RentedBooks = new List<Book>();
            foreach (var Book in ListOfRentedBooks)
            {
                RentedBooks.Add(BooksList.books.Find(x => x.ID == Book));
            }
            return RentedBooks;
        }
      
        /* METHOD:POST
        URI:https://localhost:44326/api/Rental/RentBook
        BODY:{
        "BookID":2,
        "UserID":1
        }*/
        [HttpPost("RentBook")]
        public IActionResult RentBook([FromBody] RentSet RentInfo)
        {
            if (BooksList.books.FindIndex(x => x.ID == RentInfo.BookID) != -1)
            {
                if (BooksList.books.Find(x => x.ID == RentInfo.BookID).IsRented)
                {
                    return StatusCode(409, "Book Is already rented");
                }
                else
                {
                    if (UsersList.users.FindIndex(x => x.ID == RentInfo.UserID) != -1)
                    {
                        BooksList.books[BooksList.books.FindIndex(x => x.ID == RentInfo.BookID)].IsRented = true;
                        BooksList.SaveData();
                        libraryHistory.NewRential(RentInfo.BookID,RentInfo.UserID);
                        return StatusCode(200, "OK");
                    }
                    else 
                    {
                        return StatusCode(400, "Bad Request, User not found");
                    }
                }
            }
            else
            {
                return StatusCode(400, "Bad Request, Book not found");
            }
        }
    }
}