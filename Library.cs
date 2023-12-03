using System.Data;

namespace Library_of_Fire
{
    public class Library
    {
        public Library()
        {
            AddBook();
        }

        public void AddBook() // Initializing books list
        {
            string fullPath = @"c:\Temp\BookListDownload.csv";
            if (File.Exists(fullPath))
            {
                using var fileReaderStream = new StreamReader(fullPath);

                string currentLine;
                do
                {
                    currentLine = fileReaderStream.ReadLine();
                    if (currentLine == null)
                    {
                        break;
                    }
                    string[] lines = currentLine.Split(",");
                    int bookId = int.Parse(lines[0]);
                    Book.books.Add(new Book(bookId, lines[1], lines[2], lines[3], DateOnly.Parse(lines[4]), lines[5]));
                }
                while (true);
            }
            else
            {
                Book.books.Add(new Book(1, "Whispers of the Forgotten", "Amelia Evergreen", "Checked Out", DateOnly.FromDateTime(DateTime.Now), "Angela"));
                Book.books.Add(new Book(2, "Eternal Twilight", "Sebastian Nightshade", "onShelf", DateOnly.FromDateTime(DateTime.Now), ""));
                Book.books.Add(new Book(3, "Shadows of Destiny", "Harper Blackwood", "onShelf", DateOnly.FromDateTime(DateTime.Now), ""));
                Book.books.Add(new Book(4, "The Enigma Chronicles", "Orion Steele", "onShelf", DateOnly.FromDateTime(DateTime.Now), ""));
                Book.books.Add(new Book(5, "Beyond the Horizon", "Isabella Moon", "onShelf", DateOnly.FromDateTime(DateTime.Now), ""));
                Book.books.Add(new Book(6, "Echoes of the Lost City", "Xavier Quest", "onShelf", DateOnly.FromDateTime(DateTime.Now), ""));
                Book.books.Add(new Book(7, "A Dance with Shadows", "Seraphina Nightshade", "onShelf", DateOnly.FromDateTime(DateTime.Now), ""));
                Book.books.Add(new Book(8, "Serenade of Silence", "Luna Serenity", "onShelf", DateOnly.FromDateTime(DateTime.Now), ""));
                Book.books.Add(new Book(9, "The Quantum Paradox", "Atlas Nova", "onShelf", DateOnly.FromDateTime(DateTime.Now), ""));
                Book.books.Add(new Book(10, "Harmony's End", "Aria Harmony", "onShelf", DateOnly.FromDateTime(DateTime.Now), ""));
                Book.books.Add(new Book(11, "Veil of Illusions", "Magnus Mystique", "onShelf", DateOnly.FromDateTime(DateTime.Now), ""));
                Book.books.Add(new Book(12, "Chronicles of the Celestial Isles", "Celeste Starlight", "onShelf", DateOnly.FromDateTime(DateTime.Now), ""));
                Book.books.Add(new Book(13, "The Alexandrian Wars", "Julius Ceasar", "onShelf", DateOnly.FromDateTime(DateTime.Now), ""));
                Book.books.Add(new Book(14, "The Memoirs of Cleopatra", "Margaret George", "onShelf", DateOnly.FromDateTime(DateTime.Now), ""));
            }
        }

        public void DisplayBooks()
        {
            List<Book> resultsBurned = Book.books.Where(book => book.Status == "BurnedDown").ToList();
            if (resultsBurned.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("Library Catalog:");
            foreach (Book book in Book.books)
            {
                Console.WriteLine($"\n{book.BookId}\n{book.Title}\nby {book.Author}\nStatus: {book.Status}");
                if (book.Status == "Checked Out")
                {
                    Console.WriteLine($"Due Date: {book.DueDate.ToShortDateString()}");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SearchByAuthor(string authorKeyword)
        {
            List<Book> results = Book.books.Where(book => book.Author.Contains(authorKeyword)).ToList();
            DisplaySearchResults(results, $"Search results for author '{authorKeyword}':");
        }

        public void SearchByTitle(string titleKeyword)
        {
            List<Book> results = Book.books.Where(book => book.Title.Contains(titleKeyword)).ToList();
            DisplaySearchResults(results, $"Search results for title '{titleKeyword}':");
        }
        private void DisplaySearchResults(List<Book> results, string message)
        {
            Console.WriteLine(message);
            if (results.Any())
            {
                foreach (Book book in results)
                {
                    ConsoleHelper.WriteLineColors($"{book.Title} by {book.Author}", ConsoleColor.Blue);
                    ConsoleHelper.WriteLineColors($"Status: {book.Status}", (book.Status == "Checked Out") ? ConsoleColor.Red : ConsoleColor.Green);
                    if (book.Status == "Checked Out")
                    {
                        ConsoleHelper.WriteLineColors($"This book is due back: {book.DueDate.ToShortDateString()}", ConsoleColor.Yellow);
                    }
                }
            }
            else
            {
                Console.WriteLine("No matching books found.");
            }
        }

        public void CheckOutBook()
        {
            // displays books
            // ask user what book they want to check out
            // check book status, if checked out tell user not available
            // if book is on shelf, update status to checked out
            // if book is ID 13 or 14 - tell user they burned the library down
            // show menu again to allow user to exit app
            // file is exported with updated status'

            string bookIdTxt = "";
            string CheckOutBy = "";

            DisplayBooks();

            Console.Write("Enter your name: ");
            CheckOutBy = Console.ReadLine();

            Console.Write("Enter book ID: ");
            bookIdTxt = Console.ReadLine();
            if (int.TryParse(bookIdTxt, out int bookId))
            {
                Book book = Book.books.FirstOrDefault(book => book.BookId == bookId);
                if (book != null)
                {
                    if (bookId == 13 || bookId == 14)
                    {
                        ConsoleHelper.WriteLineColors($"Congrats {CheckOutBy}, you just burned down the library of Alexandria,\nHuman Civilization will be set back by a few hundred years!!!", ConsoleColor.DarkRed);
                    }
                    else if (book.Status == "Checked Out")
                    {
                        ConsoleHelper.WriteLineColors($"{book.Title} by {book.Author} is already checked out", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteLineColors($"It will be available after: {book.DueDate}", ConsoleColor.DarkYellow);
                    }
                    else if (book.Status == "onShelf")
                    {
                        ConsoleHelper.WriteLineColors($"{book.Title} by {book.Author} has now been checked out", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteLineColors($"{book.Title} is due back by: {book.DueDate}", ConsoleColor.DarkYellow);
                        book.Status = "Checked Out";
                    }      
                }
            }
        }

        public void ReturnBook()
        {
            List<Book> resultsBurned = Book.books.Where(book => book.Status == "BurnedDown").ToList();
            if (resultsBurned.Any())
            {
                ConsoleHelper.WriteLineColors("The library of Alexandria burned down !!!!!", ConsoleColor.DarkRed);
                ConsoleHelper.WriteLineColors("You can keep the book, no need to return it.", ConsoleColor.DarkRed);
            }
            else
            {
                Console.Write("Please enter your name: ");
                string nameTxt = Console.ReadLine();
                List<Book> results = Book.books.Where(book => book.CheckOutBy == nameTxt).ToList();
                string answer;
                if (results.Count > 0)
                {
                    if (results.Count == 1)
                    {
                        ConsoleHelper.WriteLineColors($"{results[0].Title} by {results[0].Author}", ConsoleColor.DarkBlue);
                        Console.Write("Would you like to return it? y/n: ");
                        answer = Console.ReadLine().ToLower();
                        if (answer == "y")
                        {
                            foreach (Book bookList in Book.books)
                            {
                                if (bookList.BookId == results[0].BookId)
                                {
                                    bookList.Status = "onShelf";
                                    bookList.DueDate = DateOnly.FromDateTime(DateTime.Now);
                                    bookList.CheckOutBy = "";
                                    ConsoleHelper.WriteLineColors($"Thank you {nameTxt}, for returning {bookList.Title} by {bookList.Author}", ConsoleColor.DarkYellow);
                                    break;
                                }
                            }
                        }
                        else if (answer != "n")
                        {
                            ConsoleHelper.WriteLineColors("Invalid entry!!", ConsoleColor.DarkRed);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < results.Count; i++)
                        {
                            ConsoleHelper.WriteLineColors($"{i + 1}. {results[i].Title} by {results[i].Author}", ConsoleColor.DarkBlue);
                        }
                        Console.Write("Enter the number of the one you would like to return: ");
                        string bookNumTxt = Console.ReadLine();
                        if (int.TryParse(bookNumTxt, out int bookNum))
                        {
                            if (bookNum <= results.Count)
                            {
                                foreach (Book bookList in Book.books)
                                {
                                    if (bookList.BookId == results[bookNum - 1].BookId)
                                    {
                                        bookList.Status = "onShelf";
                                        bookList.DueDate = DateOnly.FromDateTime(DateTime.Now);
                                        bookList.CheckOutBy = "";
                                        ConsoleHelper.WriteLineColors($"Thank you {nameTxt}, for returning {bookList.Title} by {bookList.Author}", ConsoleColor.DarkYellow);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteLineColors("Invalid entry!!", ConsoleColor.DarkRed);
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteLineColors("Invalid entry!!", ConsoleColor.DarkRed);
                        }
                    }
                }
            }
        }
    }
}
