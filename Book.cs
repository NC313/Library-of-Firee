using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_of_Fire
{
    public class Book
    {
        public Book(string title, string author, string status, DateTime duedate)
        {
            Title = title;
            Author = author;
            Status = status;
            DueDate = duedate;
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }

    }
}