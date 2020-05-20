using Lab03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab03.Set
{
    public class LibraryHistory
    {
        private List<RentHistory> UsersRents = new List<RentHistory>();
        private List<RentHistory> BooksRents = new List<RentHistory>();

        public LibraryHistory()
        {
            LoadData();
        }

    public void NewRential(int BookId, int UserId)
        {
            if (UsersRents.FindIndex(x => x.ID == UserId) == -1)
            {
                UsersRents.Add(new RentHistory { ID = UserId, History = new List<int>() });
            }
            if (BooksRents.FindIndex(x => x.ID == BookId) == -1)
            {
                BooksRents.Add(new RentHistory { ID = BookId, History = new List<int>() });
            }

            UsersRents[UsersRents.FindIndex(x => x.ID == UserId)].History.Add(BookId);
            BooksRents[BooksRents.FindIndex(x => x.ID == BookId)].History.Add(UserId);
            SaveData();
        }
        //zwraca listę wypożyczeń danego usera
        public List<int> GetBooksRentedByUser(int UserId)
        {
            var UserHistory = UsersRents[UsersRents.FindIndex(x => x.ID == UserId)];
            return UserHistory.History;
        }
        //zwraca listę userów którzy wyporzycili książkę o ID x
        public List<int> GetUsersThatRentedBookWithId(int BookId)
        {
            var BookHistory = BooksRents[BooksRents.FindIndex(x => x.ID == BookId)];
            return BookHistory.History;
        }

        private void LoadData()
        {
            XDocument xdoc1 = XDocument.Load("Data\\BooksHistory.xml");
            foreach (var _book in xdoc1.Element("books").Elements("book"))
            {
                BooksRents.Add(new RentHistory()
                {
                    ID = int.Parse(_book.Element("ID").Value),
                    History = LoadHistory(_book.Element("History").Value)
                });
            }


            //TODO: _user
            xdoc1 = XDocument.Load("Data\\UsersHistory.xml");
            foreach (var _user in xdoc1.Element("users").Elements("user"))
            {
                UsersRents.Add(new RentHistory()
                {
                    ID = int.Parse(_user.Element("ID").Value),
                    History = LoadHistory(_user.Element("History").Value)
                });
            }
        }

        private void SaveData()
        {
            IEnumerable<XElement> serial = from user in UsersRents
                                           select new XElement("user",
                                           new XElement("ID", user.ID.ToString()),
                                           new XElement("History", string.Join(";", user.History))
                                               );
            XElement doc = new XElement("users", serial);
            doc.Save("Data\\UsersHistory.xml");

            serial = from book in BooksRents
                     select new XElement("user",
                     new XElement("ID", book.ID.ToString()),
                     new XElement("History", string.Join(";", book.History))
                         );
            doc = new XElement("books", serial);
            doc.Save("Data\\BooksHistory.xml");
        }

        private List<int> LoadHistory(string input)
        {
            string Collection = input;
            List<int> History = new List<int>();
            if (input != null && input != "")
            {
                while (Collection.IndexOf(";") != -1)
                {
                    string BookId = Collection.Substring(0, Collection.IndexOf(";"));
                    Collection = Collection.Substring(Collection.IndexOf(";") + 1);
                    History.Add(int.Parse(BookId));
                }
                History.Add(int.Parse(Collection));
            }
            return History;
        }
    }
}
