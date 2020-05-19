﻿using Lab03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            XDocument xdoc1 = XDocument.Load("Data\\BooksHistory.xml");
            foreach (var _book in xdoc1.Element("books").Elements("book"))
            {
                UsersRents.Add(new RentHistory()
                {
                    ID = int.Parse(_book.Element("ID").Value),
                    History = LoadHistory(_book.Element("History").Value)
                });
            }

            xdoc1 = XDocument.Load("Data\\UsersHistory.xml");
            foreach (var _book in xdoc1.Element("users").Elements("user"))
            {
                BooksRents.Add(new RentHistory()
                {
                    ID = int.Parse(_book.Element("ID").Value),
                    History = LoadHistory(_book.Element("History").Value)
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
