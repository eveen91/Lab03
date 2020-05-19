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

        private List<int> LoadRentData(string input)
        {
            string BookIdCollection = input;
            List<int> RentData = new List<int>();
            if (input != null && input != "")
            {
                while (BookIdCollection.IndexOf(";") != -1)
                {
                    string BookId = BookIdCollection.Substring(0, BookIdCollection.IndexOf(";"));
                    BookIdCollection = BookIdCollection.Substring(BookIdCollection.IndexOf(";") + 1);
                    RentData.Add(int.Parse(BookId));
                }
                RentData.Add(int.Parse(BookIdCollection));
            }
            return RentData;
        }


        public void SaveData()
        {
            IEnumerable<XElement> serial = from user in users
                                           select new XElement("user",
                                           new XElement("ID", user.ID.ToString()),
                                           new XElement("EMail", user.EMail),
                                           new XElement("Name", user.Name),
                                           new XElement("Surname", user.Surname),
                                           new XElement("RentHistory", string.Join(";", user.RentHistory))
                                               );
            XElement doc = new XElement("users", serial);
            doc.Save("users.xml");
        }
    }
}
