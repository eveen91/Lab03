using Lab03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab03.Set
{
    public class Books
    {
        public List<Book> books = new List<Book>();

        public Books()
        {
            LoadData();
        }

        public void AddBook(Book NewBook)
        {
            books.Add(NewBook);
            SaveData();
        }

        public void UpdateBook(string Id,Book book)
        {
            books[books.FindIndex(x => x.ID == int.Parse(Id))] = book;
            SaveData();
        }

        public void RemoveBook(string Id)
        {
            books.Remove(books.Find(x => x.ID == int.Parse(Id)));
            SaveData();
        }
        public void RentBook(int Id)
        {
            books[books.FindIndex(x => x.ID == Id)].IsRented = true;
            SaveData();
        }

        private List<Book> LoadData()
        {
            XDocument xdoc1 = XDocument.Load("Data\\books.xml");
            foreach (var _book in xdoc1.Element("books").Elements("book"))
            {
                books.Add(new Book()
                {
                    ID = int.Parse(_book.Element("ID").Value),
                    Title = _book.Element("Title").Value,
                    Author = _book.Element("Author").Value,
                    IsRented = bool.Parse(_book.Element("IsRented").Value)
                });
            }
            return books;
        }

        private void SaveData()
        {
            IEnumerable<XElement> serial = from book in books
                                           select new XElement("book",
                                           new XElement("ID", book.ID.ToString()),
                                           new XElement("Author", book.Author),
                                           new XElement("Title", book.Title),
                                           new XElement("IsRented", book.IsRented.ToString())
                                               );
            XElement doc = new XElement("books", serial);
            doc.Save("Data\\books.xml");
        }
    }
}
