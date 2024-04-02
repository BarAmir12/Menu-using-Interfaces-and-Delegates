namespace Ex04.Menus.Interfaces
{
    public interface IMenuItem
    {
        string m_Title 
        {
            get; 
        }

        void PerformAction();
        IMenuItem[] GetSubMenuItems();
        void AddSubMenuItems(IMenuItem[] i_SubMenuItems);
    }
}
