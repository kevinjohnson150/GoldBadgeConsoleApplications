using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneLibrary
{
    public class MenuItem
    {
        public string MealName { get; set; }

        public string MealNumber { get; set; }

        public string MealDescription { get; set; }

        public string Price { get; set; }

        public List<string> Ingredients { get; set; }

        public MenuItem() { }

        public MenuItem(string mealName, string mealNumber, string mealDescription, string price, List<string> ingredients)
        {
            this.MealName = mealName;
            this.MealDescription = mealDescription;
            this.MealNumber = mealNumber;
            this.Price = price;
            this.Ingredients = ingredients;
        }
    }
}
