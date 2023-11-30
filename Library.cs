﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_of_Fire
{
    public class Library
    {
        

        public Library()
        { 
          

            AddBook();

            DisplayBooks();


        }

        public void AddBook() // Initializing books list
        {            

            Book.books.Add(new Book("Whispers of the Forgotten", "Amelia Evergreen", "onShelf", DateTime.Now));
            Book.books.Add(new Book("Eternal Twilight", "Sebastian Nightshade", "onShelf", DateTime.Now));
            Book.books.Add(new Book("Shadows of Destiny", "Harper Blackwood", "onShelf", DateTime.Now));
            Book.books.Add(new Book("The Enigma Chronicles", "Orion Steele", "onShelf", DateTime.Now));
            Book.books.Add(new Book("Beyond the Horizon", "Isabella Moon", "onShelf", DateTime.Now));
            Book.books.Add(new Book("Echoes of the Lost City", "Xavier Quest", "onShelf", DateTime.Now));
            Book.books.Add(new Book("A Dance with Shadows", "Seraphina Nightshade", "onShelf", DateTime.Now));
            Book.books.Add(new Book("Serenade of Silence", "Luna Serenity", "onShelf", DateTime.Now));
            Book.books.Add(new Book("The Quantum Paradox", "Atlas Nova", "onShelf", DateTime.Now));
            Book.books.Add(new Book("Harmony's End", "Aria Harmony", "onShelf", DateTime.Now));
            Book.books.Add(new Book("Veil of Illusions", "Magnus Mystique", "onShelf", DateTime.Now));
            Book.books.Add(new Book("Chronicles of the Celestial Isles", "Celeste Starlight", "onShelf", DateTime.Now));
        }

        public void DisplayBooks()
        {
            Console.WriteLine("Library Catalog:");
            foreach (Book book in Book.books)
            {

                Console.WriteLine($"{book.Title} by {book.Author} - Status: {book.Status}");
                if (book.Status == "Checked Out")
                {
                    Console.WriteLine($"Due Date: {book.DueDate.ToShortDateString()}");
                }            
            }
        }
    }
}
