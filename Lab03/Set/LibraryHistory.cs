using Lab03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03.Set
{
    public class LibraryHistory
    {
        List<RentHistory> UsersRents = new List<RentHistory>();
        List<RentHistory> BooksRents = new List<RentHistory>();

        LibraryHistory()
        {
            LoadData();
        }

        void NewRential(int BookId, int UserId)
        {
            UsersRents[UsersRents.FindIndex(x => x.ID == UserId)].History.Add(BookId);
            BooksRents[BooksRents.FindIndex(x => x.ID == BookId)].History.Add(UserId);
            SaveData();
        }


        public List<int> GetBooksRentedByUser(int UserId)
        {
            var UserHistory = UsersRents[UsersRents.FindIndex(x => x.ID == UserId)];
            return UserHistory.History;
        }

        public List<int> GetUsersRentedBookById(int BookId)
        {
            var BookHistory = BooksRents[BooksRents.FindIndex(x => x.ID == BookId)];
            return BookHistory.History;
        }

        private void LoadData()
        {
        
        }

        private void SaveData()
        {
        
        }
    }
}
