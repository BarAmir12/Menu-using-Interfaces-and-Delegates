using System;

namespace Ex04.Menus.Test
{
    internal class Functions
    {
        public static Action CreateDateTimeAction(bool i_IsDate)
        {
            return () =>
            {
                if (i_IsDate)
                {
                    Console.WriteLine($"The Date is: {DateTime.Now:yyyy-MM-dd}");
                }
                else
                {
                    Console.WriteLine($"The Hour is: {DateTime.Now:HH:mm:ss}");
                }
            };
        }

        public static void CountCapitals()
        {
            Console.WriteLine("Please enter your sentence:");
            string sentence = Console.ReadLine();
            int count = 0;

            foreach (char c in sentence)
            {
                if (char.IsUpper(c))
                {
                    count++;
                }
            }

            Console.WriteLine($"There are {count} capitals in your sentence.");
            Console.WriteLine();
        }

        public static void ShowVersion()
        {
            Console.WriteLine("Version: 24.1.4.9633");
            Console.WriteLine();
        }
    }
}
