using ChallengeOneLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneTests
{
    [TestClass]
    public class MenuItemRepoTests
    {
        private MenuItemRepo _repo;
        private MenuItem _menu;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemRepo();
            _menu = new MenuItem("Chicken Nuggets", "5", "Chicken Nuggets and Fries", "$6.99", new List<string> { "Chicken" });

            _repo.AddMenuItem(_menu);
        }

        [TestMethod]
        public void AddMenuItemToList_ShouldNotGetNull()
        {
            MenuItem menuItem = new MenuItem();
            menuItem.MealNumber = "5";
            MenuItemRepo repository = new MenuItemRepo();

            repository.AddMenuItem(menuItem);
            MenuItem menuItemFromList = repository.GetMenuItemByNumber("5");

            Assert.IsNotNull(menuItemFromList);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {

            bool deleteMenuItem = _repo.RemoveMenuItem(_menu.MealNumber);

            Assert.IsTrue(deleteMenuItem);
        }

    }
}
