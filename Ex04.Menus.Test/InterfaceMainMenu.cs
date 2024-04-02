using System;


namespace Ex04.Menus.Test
{
    internal class InterfaceMainMenu
    {
        public static void DisplayInterfaceMenu()
        {
            var mainMenuInterfaces = new Ex04.Menus.Interfaces.MainMenu();

            mainMenuInterfaces.AddMenuItem(CreateDateTimeSubMenuInterface());
            mainMenuInterfaces.AddMenuItem(CreateVersionAndCapitalsSubMenuInterface());
            mainMenuInterfaces.Show();
        }

        static Ex04.Menus.Interfaces.MenuItem CreateDateTimeSubMenuInterface()
        {
            var dateItem = new Ex04.Menus.Interfaces.MenuItem("Show Date", Functions.CreateDateTimeAction(true));
            var timeItem = new Ex04.Menus.Interfaces.MenuItem("Show Time", Functions.CreateDateTimeAction(false));

            return new Ex04.Menus.Interfaces.MenuItem("Show Date/Time", null, new[] { dateItem, timeItem });
        }

        static Ex04.Menus.Interfaces.MenuItem CreateVersionAndCapitalsSubMenuInterface()
        {
            var countCapitalsItem = new Ex04.Menus.Interfaces.MenuItem("Count Capitals", new Action(Functions.CountCapitals));
            var showVersionItem = new Ex04.Menus.Interfaces.MenuItem("Show Version", new Action(Functions.ShowVersion));

            return new Ex04.Menus.Interfaces.MenuItem("Version and Capitals", null, new[] { countCapitalsItem, showVersionItem });
        }

    }
}
