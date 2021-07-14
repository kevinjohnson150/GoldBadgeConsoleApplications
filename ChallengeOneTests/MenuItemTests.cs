using ChallengeOneLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeOneTests
{
    [TestClass]
    public class MenuItemTests
    {
        [TestMethod]
        public void NewMealName_ShouldSetNewMealName()
        {
            MenuItem meal = new MenuItem();

            meal.MealName = "Chicken Nuggets";

            string expected = "Chicken Nuggets";
            string actual = meal.MealName;

            Assert.AreEqual(expected, actual);
        }
    }
}
