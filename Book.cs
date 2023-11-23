using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_of_Fire
{
    public class Book
    {
        public Book(string _title, string _author, string _status, DateOnly _checkoutdate) 
        {
            Title = _title;
            Author = _author;
            Status = _status;
            CheckoutDate = _checkoutdate;
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public DateOnly CheckoutDate { get; set; }       
    }
}
