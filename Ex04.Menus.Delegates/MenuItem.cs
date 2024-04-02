using System;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        private string m_Title;
        private Action m_Action;
        private MenuItem[] m_SubMenuItems;

        public MenuItem(string i_Title, Action i_Action = null, MenuItem[] i_SubMenuItems = null)
        {
            m_Title = i_Title;
            m_Action = i_Action;
            m_SubMenuItems = i_SubMenuItems;
        }

        public string Title
        {
            get 
            {
                return m_Title; 
            }
            set
            {
                m_Title = value; 
            }
        }

        public Action Action
        {
            get
            {
                return m_Action; 
            }
            set
            {
                m_Action = value; 
            }
        }

        public MenuItem[] SubMenuItems
        {
            get
            {
                return m_SubMenuItems; 
            }
            set
            {
                m_SubMenuItems = value; 
            }
        } 
    }
}
