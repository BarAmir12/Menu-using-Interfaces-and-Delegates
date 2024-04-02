using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private List<MenuItem> m_MenuItems;

        public MainMenu()
        {
            m_MenuItems = new List<MenuItem>();
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            m_MenuItems.Add(i_MenuItem);
        }

        public void Show()
        {
            int choice;
            bool isRunning = true;

            do
            {
                DisplayMainMenu();

                try
                {
                    choice = GetValidChoice();
                }
                catch (ArgumentException ex)
                {
                    ConsoleUI.WriteLine(ex.Message);
                    continue;
                }

                if (choice == 0) break;

                DisplaySubMenu(m_MenuItems[choice - 1]);
            } while (isRunning);
        }

        private int GetValidChoice()
        {
            string input = PromptUser.GetInput();

            if (!PromptUser.TryParseInt(input, out int choice) || choice < 0 || choice > m_MenuItems.Count)
            {
                throw new ArgumentException("Invalid input. Please enter a valid option.");
            }

            return choice;
        }

        private void DisplayMainMenu()
        {
            ConsoleUI.WriteLine("**Delegates Main Menu**");
            ConsoleUI.WriteLine("----------------------------");

            for (int i = 0; i < m_MenuItems.Count; i++)
            {
                ConsoleUI.WriteLine($"{i + 1} -> {m_MenuItems[i].Title}");
            }

            ConsoleUI.WriteLine("0 -> Exit");
            ConsoleUI.WriteLine("----------------------------");
            ConsoleUI.WriteLine("Enter your request: (1 to " + m_MenuItems.Count + " or press '0' to Exit).");
        }

        public void DisplaySubMenu(MenuItem i_MenuItem)
        {
            int choice;
            bool isRunning = true;

            do
            {
                DisplaySubMenuHeader(i_MenuItem);

                try
                {
                    choice = GetSubMenuChoice(i_MenuItem);
                }
                catch (ArgumentException ex)
                {
                    ConsoleUI.WriteLine(ex.Message);
                    continue;
                }

                if (choice == 0)
                {
                    break;
                }

                i_MenuItem.SubMenuItems[choice - 1].Action?.Invoke();
                ConsoleUI.WriteLine("");
                ConsoleUI.WriteLine("");
            } while (isRunning);
        }

        private void DisplaySubMenuHeader(MenuItem i_MenuItem)
        {
            ConsoleUI.WriteLine($"**{i_MenuItem.Title}**");
            ConsoleUI.WriteLine("----------------------------");

            for (int i = 0; i < i_MenuItem.SubMenuItems.Length; i++)
            {
                ConsoleUI.WriteLine($"{i + 1} -> {i_MenuItem.SubMenuItems[i].Title}");
            }

            ConsoleUI.WriteLine("0 -> Back");
            ConsoleUI.WriteLine("----------------------------");
            ConsoleUI.WriteLine($"Enter your request: (1 to {i_MenuItem.SubMenuItems.Length} or press '0' to Back).");
        }

        private int GetSubMenuChoice(MenuItem i_MenuItem)
        {
            string subMenuInput = PromptUser.GetInput();


            if (!PromptUser.TryParseInt(subMenuInput, out int choice) || choice < 0 || choice > i_MenuItem.SubMenuItems.Length)
            {
                throw new ArgumentException("Invalid input.");
            }

            return choice;
        }

    }
}