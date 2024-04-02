using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private List<IMenuItem> m_MenuItems;

        public MainMenu()
        {
            m_MenuItems = new List<IMenuItem>();
        }

        public void AddMenuItem(IMenuItem i_MenuItem)
        {
            m_MenuItems.Add(i_MenuItem);
        }

        public void Show()
        {
            int choice;

            do
            {
                DisplayMainMenu();

                try
                {
                    choice = GetValidChoice(m_MenuItems.Count);
                }
                catch (ArgumentException ex)
                {
                    ConsoleUI.WriteLine(ex.Message);
                    continue;
                }

                if (choice == 0) break;

                ProcessMenuItem(m_MenuItems[choice - 1]);
            } while (true);
        }

        private int GetValidChoice(int maxChoice)
        {
            string input = PromptUser.GetInput();
            if (!int.TryParse(input, out int choice) || choice < 0 || choice > maxChoice)
            {
                throw new ArgumentException("Invalid input. Please enter a valid option.");
            }
            return choice;
        }

        private void DisplayMainMenu()
        {
            ConsoleUI.WriteLine("**Interfaces Main Menu**");
            ConsoleUI.WriteLine("----------------------------");
            for (int i = 0; i < m_MenuItems.Count; i++)
            {
                ConsoleUI.WriteLine($"{i + 1} -> {m_MenuItems[i].m_Title}");
            }
            ConsoleUI.WriteLine("0 -> Exit");
            ConsoleUI.WriteLine("----------------------------");
            ConsoleUI.WriteLine("Enter your request: (1 to " + m_MenuItems.Count + " or press '0' to Exit).");
        }

        private void ProcessMenuItem(IMenuItem i_MenuItem)
        {
            if (i_MenuItem.GetSubMenuItems() != null)
            {
                ShowSubMenu(i_MenuItem);
            }
            else
            {
                i_MenuItem.PerformAction();
                ConsoleUI.WriteLine("");
                ConsoleUI.WriteLine("");
            }
        }

        private void ShowSubMenu(IMenuItem i_MenuItem)
        {
            int choice;
            do
            {
                DisplaySubMenuTitle(i_MenuItem);

                try
                {
                    choice = GetValidChoice(i_MenuItem.GetSubMenuItems().Length);
                }
                catch (ArgumentException ex)
                {
                    ConsoleUI.WriteLine(ex.Message);
                    continue;
                }

                if (choice == 0) break;

                ProcessMenuItem(i_MenuItem.GetSubMenuItems()[choice - 1]);
            } while (true);
        }

        private void DisplaySubMenuTitle(IMenuItem i_MenuItem)
        {
            ConsoleUI.WriteLine("**" + i_MenuItem.m_Title + "**");
            ConsoleUI.WriteLine("----------------------------");
            for (int i = 0; i < i_MenuItem.GetSubMenuItems().Length; i++)
            {
                ConsoleUI.WriteLine($"{i + 1} -> {i_MenuItem.GetSubMenuItems()[i].m_Title}");
            }
            ConsoleUI.WriteLine("0 -> Back");
            ConsoleUI.WriteLine("----------------------------");
            ConsoleUI.WriteLine("Enter your request: (1 to " + i_MenuItem.GetSubMenuItems().Length + " or press '0' to Back).");
        }
    }
}