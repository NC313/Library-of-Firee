using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_of_Fire
{
    internal class Library
    {
        private List<Book> books = new List<Book>();

        public Library()
        {
            books = new List<Book>();

            new Book("Whispers of the Forgotten", "Amelia Evergreen", "onShelf", DateTime.Now);
            new Book("Eternal Twilight", "Sebastian Nightshade", "onShelf", DateTime.Now);
            new Book("Shadows of Destiny", "Harper Blackwood", "onShelf", DateTime.Now);
            new Book("The Enigma Chronicles", "Orion Steele", "onShelf", DateTime.Now);
            new Book("Beyond the Horizon", "Isabella Moon", "onShelf", DateTime.Now);
            new Book("Echoes of the Lost City", "Xavier Quest", "onShelf", DateTime.Now);
            new Book("A Dance with Shadows", "Seraphina Nightshade", "onShelf", DateTime.Now);
            new Book("Serenade of Silence", "Luna Serenity", "onShelf", DateTime.Now);
            new Book("The Quantum Paradox", "Atlas Nova", "onShelf", DateTime.Now);
            new Book("Harmony's End", "Aria Harmony", "onShelf", DateTime.Now);
            new Book("Veil of Illusions", "Magnus Mystique", "onShelf", DateTime.Now);
            new Book("Chronicles of the Celestial Isles", "Celeste Starlight", "onShelf", DateTime.Now);
        }

        public void AddBook(Book book) // heads up we might need to move this or add a semicolon
        {
            books.Add(book);
        }

        public void DisplayBooks()
        {
            Console.WriteLine("Library Catalog:");
            Console.WriteLine("------------------------------");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} by {book.Author} - Status: {book.Status}");
                if (book.Status == "Checked Out")
                {
                    Console.WriteLine($"Due Date: {book.DueDate.ToShortDateString()}");
                }
                Console.WriteLine("------------------------------");
            }
        }
    }  
    
}
