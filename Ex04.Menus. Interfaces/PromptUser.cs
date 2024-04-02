using System;

namespace Ex04.Menus.Interfaces
{
    public class PromptUser
    {
        public static string GetInput()
        {
            return Console.ReadLine();
        }

        public static bool TryParseInt(string input, out int result)
        {
            return int.TryParse(input, out result);
        }
    }
}
