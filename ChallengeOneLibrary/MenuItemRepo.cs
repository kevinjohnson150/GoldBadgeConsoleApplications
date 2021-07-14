using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneLibrary
{
    public class MenuItemRepo
    {
        public List<MenuItem> _listOfMenuItemsRepo = new List<MenuItem>();

        // Create
        public void AddMenuItem(MenuItem menuItem)
        {
            _listOfMenuItemsRepo.Add(menuItem);
        }

        // Read
        public List<MenuItem> MenuList()
        {
            return _listOfMenuItemsRepo;
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

            int menuItemCount = _listOfMenuItemsRepo.Count;
            _listOfMenuItemsRepo.Remove(menuItem);

            if (menuItemCount > _listOfMenuItemsRepo.Count)
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
            foreach (MenuItem menuItem in _listOfMenuItemsRepo)
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
