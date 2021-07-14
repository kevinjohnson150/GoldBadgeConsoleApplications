using ChallengeOneLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneApp
{
    public class ProgramUI
    {
        private MenuItemRepo _listOfMenuItemsRepo = new MenuItemRepo();
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option below: \n" +
                    "1. Create Menu Item \n" +
                    "2. Delete Menu Item \n" +
                    "3. List Of Menu Items \n" +
                    "10. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ListOfMenuItems();
                        break;
                    case "10":
                        Console.WriteLine("Have a great day!!!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid response please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewMenuItem()
        {
            Console.Clear();
            MenuItem newMenuItem = new MenuItem();

            Console.WriteLine("Enter the name of the meal you would like to add:");
            newMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter the number for the meal:");
            newMenuItem.MealNumber = Console.ReadLine();

            Console.WriteLine("Enter the description for the meal:");
            newMenuItem.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the price for the meal:");
            newMenuItem.Price = Console.ReadLine();

            Console.WriteLine("List the ingredients for the meal items:\n" +
                "(After you have added all of the ingredients press enter TWICE to confirm.)");
            List<string> listOfIngredients = AddListOfIngredients();
            newMenuItem.Ingredients = listOfIngredients;
            
            _listOfMenuItemsRepo.AddMenuItem(newMenuItem);
        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Enter the meal number you would like to remove:");
            string mealNumber = Console.ReadLine();

            bool mealRemoved = _listOfMenuItemsRepo.RemoveMenuItem(mealNumber);

            if (mealRemoved)
            {
                Console.WriteLine("The meal has been removed from the menu!");
            }
            else
            {
                Console.WriteLine("Sorry... The meal was not removed. Please try again.");
            }
        }

        private void ListOfMenuItems()
        {
            Console.Clear();
            List<MenuItem> listOfMenuItems = _listOfMenuItemsRepo.MenuList();

            foreach (MenuItem menuItem in listOfMenuItems)
            {
                Console.WriteLine($"Meal Name: {menuItem.MealName} \n" +
                    $"Meal Number: {menuItem.MealNumber} \n" +
                    $"Meal Price: {menuItem.Price} \n" +
                    $"Meal Description: {menuItem.MealDescription}\n");
                foreach (string ingredients in menuItem.Ingredients)
                {
                    Console.WriteLine($"Meal Ingredients: {ingredients}\n");
                }
            }
            
        }

        public List<string> AddListOfIngredients()
        {
            List<string> listOfIngredients = new List<string>();

            bool addingIngredients = true;
            while (addingIngredients)
            {
                string userInput = Console.ReadLine();
                if (userInput != "")
                {
                    listOfIngredients.Add(userInput);
                }
                else
                {
                    addingIngredients = false;
                }
            }
            return listOfIngredients;
        }
    }
}
