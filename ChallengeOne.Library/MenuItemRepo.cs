using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.Library
{
    public class MenuItemRepo
    {
        public List<MenuItem> _listOfMenuItems = new List<MenuItem>();

        // Create
        public void AddMenuItem(MenuItem menuItem)
        {
            _listOfMenuItems.Add(menuItem);
        }

        // Read
        public List<MenuItem> MenuList()
        {
            return _listOfMenuItems;
        }

        // Update



        // Delete
        public bool RemoveMenuItem(string menuItemNumber)
        {
            MenuItem menuItem = GetMenuItemByNumber(menuItemNumber);

            if (menuItem == null)
            {
                return false;
            }

            int menuItemCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(menuItem);

            if (menuItemCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper Method
        public MenuItem GetMenuItemByNumber(string oldMenuItem)
        {
            foreach (MenuItem menuItem in _listOfMenuItems)
            {
                if (menuItem.MealNumber.ToLower() == oldMenuItem.ToLower())
                {
                    return menuItem;
                }
            }
            return null;
        }
    }
}


