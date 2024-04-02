using System;

namespace Ex04.Menus.Interfaces
{
    public class ConsoleUI
    {
        public static void WriteLine(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        public static void Write(string i_Message)
        {
            Console.Write(i_Message);
        }
    }
}