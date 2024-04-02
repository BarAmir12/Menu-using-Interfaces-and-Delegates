using System;

namespace Ex04.Menus.Test
{
    internal class DelegateMainMenu
    {
        public static void DisplayDelegateMenu()
        {
            var mainMenuDelegates = new Ex04.Menus.Delegates.MainMenu();

            mainMenuDelegates.AddMenuItem(CreateDateTimeSubMenu());
            mainMenuDelegates.AddMenuItem(CreateVersionAndCapitalsSubMenu());
            mainMenuDelegates.Show();
        }

        static Ex04.Menus.Delegates.MenuItem CreateDateTimeSubMenu()
        {
            var dateItem = new Ex04.Menus.Delegates.MenuItem("Show Date", Functions.CreateDateTimeAction(true));
            var timeItem = new Ex04.Menus.Delegates.MenuItem("Show Time", Functions.CreateDateTimeAction(false));

            return new Ex04.Menus.Delegates.MenuItem("Show Date/Time", null, new[] { dateItem, timeItem });
        }

        static Ex04.Menus.Delegates.MenuItem CreateVersionAndCapitalsSubMenu()
        {
            var countCapitalsItem = new Ex04.Menus.Delegates.MenuItem("Count Capitals", Functions.CountCapitals);
            var showVersionItem = new Ex04.Menus.Delegates.MenuItem("Show Version", Functions.ShowVersion);

            return new Ex04.Menus.Delegates.MenuItem("Version and Capitals", null, new[] { countCapitalsItem, showVersionItem });
        }

    }
}
