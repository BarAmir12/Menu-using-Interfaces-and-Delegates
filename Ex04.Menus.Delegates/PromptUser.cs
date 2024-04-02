using System;

namespace Ex04.Menus.Delegates
{
    public class PromptUser
    {
        public static string GetInput()
        {
            return Console.ReadLine();
        }

        public static bool TryParseInt(string i_Input, out int o_Result)
        {
            return int.TryParse(i_Input, out o_Result);
        }
    }
}
