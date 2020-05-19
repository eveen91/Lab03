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

        //userzy który wyporzyczyli daną książkę
        [HttpGet("BookRentedByUsers/{Id}")]
        public List<User> BookRentedByUser(string Id)
        {
            /* var GivenBook = BooksList.books[BooksList.books.FindIndex(x => x.ID == int.Parse(Id))];
             List<User> LendersList = new List<User>();
             foreach (var UserId in GivenBook.RentHistory)
             {
                 LendersList.Add(UsersList.users.Find(x => x.ID == UserId));
             }
             return LendersList;*/

            List<User> LendersList = new List<User>();
            var ListOfUsers = libraryHistory.GetUsersThatRentedBookWithId(int.Parse(Id));
            foreach (var User in ListOfUsers)
            {
                LendersList.Add(UsersList.users.Find(x => x.ID == User));
            }
            return LendersList;
        }

        //książki wyporzyczone prze usera o id
        [HttpGet("UserHistoryRent/{Id}")]
        public List<Book> UserHistoryRent(string Id)
        {
            /*            var GivenUser = UsersList.users[UsersList.users.FindIndex(x => x.ID == int.Parse(Id))];
                        List<Book> RentedBooks = new List<Book>();
                        foreach (var BookId in GivenUser.RentHistory)
                        {
                            RentedBooks.Add(BooksList.books.Find(x => x.ID == BookId));
                        }
                        return RentedBooks;*/
            var ListOfRentedBooks = libraryHistory.GetBooksRentedByUser(int.Parse(Id));
            List<Book> RentedBooks = new List<Book>();
            foreach (var Book in ListOfRentedBooks)
            {
                RentedBooks.Add(BooksList.books.Find(x => x.ID == Book));
            }
            return RentedBooks;

        }

    }
}