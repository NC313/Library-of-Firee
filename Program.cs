namespace Library_of_Fire;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();          
        EnumVal enumVal = 0;
        
        do
        {
            enumVal = Menu.PrintMenu();
            Console.Clear();
            switch (enumVal)
            {
                case EnumVal.DisplayBooks:
                    library.DisplayBooks();
                    break;
                case EnumVal.SearchByAuthor:
                    Console.Write("Enter author's name: ");                    
                    library.SearchByAuthor(Console.ReadLine());                    
                    break;
                case EnumVal.SearchByTitle:
                    Console.Write("Enter book's title: ");
                    library.SearchByTitle(Console.ReadLine());
                    break;
                case EnumVal.CheckOut:                    
                    library.CheckOutBook();
                    break;
                case EnumVal.ReturnBook:                    
                    library.ReturnBook();
                    break;
                case EnumVal.Exit:
                    Book.SaveBookList();
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            ConsoleHelper.ReadLineClear();
            
        } while (enumVal != EnumVal.Exit);        
    }    

}
