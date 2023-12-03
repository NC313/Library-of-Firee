namespace Library_of_Fire
{
    internal class Menu
    {
        public static EnumVal PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Please enter a valid number selection");

                var selectionRange = Enumerable.Range(1, 6);
                var choices = new string[] { "Display all books", "Search by Author", "Search by Title", "Check out book", "Return book", "Exit" };
                                
                foreach (var choice in selectionRange.Zip(choices, (i, s) => $"[{i}]. {s}"))
                {
                    ConsoleHelper.WriteLineColors(choice, ConsoleColor.Cyan);
                }

                Console.Write("Enter your selection: ");
                if (Enum.TryParse(Console.ReadLine(), out EnumVal menu) && selectionRange.Contains((int)menu))
                {
                    return menu;
                }

                Console.WriteLine("Invalid input, please try again...");
                ConsoleHelper.ReadLineClear();
            }
        }
    }
}
