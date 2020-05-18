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

        public void AddBook(string ID, string EMail, string Name, string Surname)
        {
            users.Add(new User() { ID = int.Parse(ID), EMail = EMail, Name = Name, Surname = Surname });
        }

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
                    Surname = _user.Element("Surname").Value
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
                                           new XElement("Surname", user.Surname)
                                               );
            XElement doc = new XElement("users", serial);
            doc.Save("users.xml");
        }
    }
}
