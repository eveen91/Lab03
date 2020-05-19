using Lab03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab03
{
    public class Users
    {
        public Users()
        {
            LoadData();
        }
        public List<User> users = new List<User>();

        public List<User> LoadData()
        {
            XDocument xdoc1 = XDocument.Load("users.xml");
            foreach (var _user in xdoc1.Element("users").Elements("user"))
            {
                users.Add(new User()
                {
                    ID = int.Parse(_user.Element("ID").Value),
                    EMail = _user.Element("EMail").Value,
                    Name = _user.Element("Name").Value,
                    Surname = _user.Element("Surname").Value,
                    RentHistory = LoadRentData(_user.Element("RentHistory").Value)
                });
            }
            return users;
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
        /*        public int AddBookToRentalHistory()
                { 

                }*/
    }
}
