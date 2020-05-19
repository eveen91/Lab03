using Lab03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Book> LoadData()
        {
            XDocument xdoc1 = XDocument.Load("Data\books.xml");
            //List<Book> books = new List<Book>();
            foreach (var _book in xdoc1.Element("books").Elements("book"))
            {
                books.Add(new Book()
                {
                    ID = int.Parse(_book.Element("ID").Value),
                    Title = _book.Element("Title").Value,
                    Author = _book.Element("Author").Value,
                    IsRented = bool.Parse(_book.Element("IsRented").Value),
                    RentHistory = LoadRentData(_book.Element("RentHistory").Value)
                });
            }
            return books;
        }

        public void SaveData()
        {
            IEnumerable<XElement> serial = from book in books
                                           select new XElement("book",
                                           new XElement("ID", book.ID.ToString()),
                                           new XElement("Author", book.Author),
                                           new XElement("Title", book.Title),
                                           new XElement("IsRented", book.IsRented.ToString()),
                                           new XElement("RentHistory", string.Join(";",book.RentHistory))
                                               );
            XElement doc = new XElement("books", serial);
            doc.Save("books.xml");
        }

        private List<int> LoadRentData(string input)
        {
            string LenderID = input;
            List<int> RentData = new List<int>();
            if (input != null && input != "")
            {
                while (LenderID.IndexOf(";") != -1)
                {
                    string BookId = LenderID.Substring(0, LenderID.IndexOf(";"));
                    LenderID = LenderID.Substring(LenderID.IndexOf(";") + 1);
                    RentData.Add(int.Parse(BookId));
                }
                RentData.Add(int.Parse(LenderID));
            }
            return RentData;
        }
    }
}
