using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenuItem
    {
        public string m_Title
        {
            get;
            private set; 
        }
        private Action m_Action;
        private IMenuItem[] m_SubMenuItems;

        public MenuItem(string i_Title, Action i_Action = null, IMenuItem[] i_SubMenuItems = null)
        {
            m_Title = i_Title;
            m_Action = i_Action;
            m_SubMenuItems = i_SubMenuItems;
        }

        public void PerformAction()
        {
            m_Action?.Invoke();
        }

        public IMenuItem[] GetSubMenuItems()
        {
            return m_SubMenuItems;
        }

        public void AddSubMenuItems(IMenuItem[] i_SubMenuItems)
        {
            m_SubMenuItems = i_SubMenuItems;
        }
    }
}
