namespace Library_of_Fire
{
    public class Book
    {
        public Book(int bookId, string title, string author, string status, DateOnly duedate, string checkedoutby)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            Status = status;
            DueDate = duedate;
            CheckOutBy = checkedoutby;
        }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public DateOnly DueDate { get; set; }
        public string CheckOutBy { get; set; }

        public static List<Book> books = new List<Book>();

        public static void SaveBookList()
        {
            string fullPath = @"c:\Temp\BookListDownload.csv";
            var fs = new FileStream(fullPath, FileMode.OpenOrCreate);
            using var stream = new StreamWriter(fs);
            for (int i = 0; i < Book.books.Count; i++)
            {
                string printLine = ($"{books[i].BookId},{books[i].Title},{books[i].Author},{books[i].Status},{books[i].DueDate},{books[i].CheckOutBy}");
                stream.WriteLine(printLine);
            }
            stream.Close();
        }

    }
}