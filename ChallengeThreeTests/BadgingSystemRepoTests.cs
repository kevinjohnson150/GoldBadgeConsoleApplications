using ChallengeThreeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThreeTests
{
    [TestClass]
    public class BadgingSystemRepoTests
    {
        [TestMethod]
        public void AddBadge_ShouldReturnFalse()
        {
            BadgingSystem badge = null;
            BadgingSystemRepo repo = new BadgingSystemRepo();

            bool result = repo.AddBadgeToDictionary(badge);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddBadge_ShouldReturnTrue()
        {
            BadgingSystem badge = new BadgingSystem(28, new List<string> { "Door 56", "Door 25" });
            BadgingSystemRepo repo = new BadgingSystemRepo();

            bool result = repo.AddBadgeToDictionary(badge);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetBadgeByID_ShouldReturnBadge()
        {
            BadgingSystem badge = new BadgingSystem(28, new List<string> { "Door 56", "Door 25" });
            BadgingSystemRepo repo = new BadgingSystemRepo();
            repo.AddBadgeToDictionary(badge);
            

            BadgingSystem result = repo.GetBadgeByID(badge.BadgeID);

            Assert.AreEqual(badge.BadgeID, result.BadgeID);
        }
    }
}
