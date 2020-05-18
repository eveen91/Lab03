using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsRented { get; set; }

        public string ToString()
        {
            return ID.ToString() + " " + Title + " " + Author + " " + IsRented.ToString();
        }
    }
}
