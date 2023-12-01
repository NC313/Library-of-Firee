using static System.Reflection.Metadata.BlobBuilder;

namespace Library_of_Fire;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        Book.SaveBookList();
    }    
}
