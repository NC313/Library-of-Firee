namespace Library_of_Fire
{
    public static class ConsoleHelper
    {
        public static void WriteLineColors(string message, ConsoleColor color, ConsoleColor defaultColor = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = defaultColor;
        }

        public static void WriteColors(string message, ConsoleColor color, ConsoleColor defaultColor = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = defaultColor;
        }

        public static void ReadLineClear()
        {
            Console.ReadLine();
            Console.Clear();
        }
    }
}
