using ChallengeThreeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeApp
{
   public class ProgramUI
   {
        private readonly BadgingSystemRepo _badgeDictionaryRepo = new BadgingSystemRepo();
        public void Run()
        {
            SeedBadgeList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("---- KOMODO INSURANCE BADGING SYSTEM ----\n\n" +
                    "Select a menu option:\n" +
                    "1. Add A Badge\n" +
                    "2. Edit A Badge\n" +
                    "3. List All Badges\n" +
                    "10. Exit\n" +
                    "----------------------------------------------------\n");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "10":
                        Console.WriteLine("GOODBYE!!!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number....");
                        break;
                }

                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddABadge()
        {
            Console.Clear();

            Console.WriteLine("Enter the badge number you would like to add:");
            int badgeID = int.Parse(Console.ReadLine());

            List<string> doorNames = AddListToDoors();

            BadgingSystem newBadge = new BadgingSystem(badgeID, doorNames);
            _badgeDictionaryRepo.AddBadgeToDictionary(newBadge);
        }

        private List<string> AddListToDoors()
        {
            List<string> doorNames = new List<string>();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Enter the door name that the badge needs access to: ");
                string input = Console.ReadLine();
                doorNames.Add(input);

                Console.WriteLine("Are there any other doors you would like to add? (y/n)");
                if (Console.ReadLine().ToLower() == "y") 
                {
                    keepRunning = true;
                }
                else
                {
                    keepRunning = false;
                }
            }

            return doorNames;
        }

        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badgeDictionary = _badgeDictionaryRepo.GetBadgeList();

            Console.WriteLine(badgeDictionary);
        }

        public void EditBadge()
        {
            Console.WriteLine("What is the badge number you would like to update?");
            int badgeID = int.Parse(Console.ReadLine());

            BadgingSystem badgeToUpdate = _badgeDictionaryRepo.GetBadgeByID(badgeID);

            if (badgeToUpdate != null)
            {
                Console.WriteLine($"{badgeID} has access to the door/doors: {badgeToUpdate} \n");
                
            }

            Console.WriteLine("Pick an option below to to proceed: \n" +
                "1. Remove door \n" +
                "2. Add door");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Which door do you want remove?");
                    string doorToRemoved = Console.ReadLine();
                    if (badgeToUpdate.DoorNames.Contains(doorToRemoved))
                    {
                        badgeToUpdate.DoorNames.Remove(doorToRemoved);
                        Console.WriteLine("Door Was Removed");
                    }
                    else
                    {
                        Console.WriteLine($"{badgeID} is not linked to that door.");
                    }
                    Console.WriteLine($"{badgeID} now has access to {badgeToUpdate.BadgeID}.");
                    break;
                case "2":
                    Console.WriteLine("List the door name that you wish to add: ");
                    string doorAdded = Console.ReadLine();
                    badgeToUpdate.DoorNames.Add(doorAdded);
                    break;
            }
        }

        public void SeedBadgeList()
        {
            BadgingSystem badge1 = new BadgingSystem(12, new List<string> {"Door 156", "Door 51" });
            BadgingSystem badge2 = new BadgingSystem(95, new List<string> { "Door 51", "Door 1" });
            BadgingSystem badge3 = new BadgingSystem(8, new List<string> { "Door 23", "Door 5" });
            BadgingSystem badge4 = new BadgingSystem(8, new List<string> { "Door 19", "Door 87" });
            BadgingSystem badge5 = new BadgingSystem(8, new List<string> { "Door 31", "Door 64" });
            BadgingSystem badge6 = new BadgingSystem(8, new List<string> { "Door 72", "Door 51" });
            _badgeDictionaryRepo.AddBadgeToDictionary(badge1);
            _badgeDictionaryRepo.AddBadgeToDictionary(badge2);
            _badgeDictionaryRepo.AddBadgeToDictionary(badge3);
            _badgeDictionaryRepo.AddBadgeToDictionary(badge4);
            _badgeDictionaryRepo.AddBadgeToDictionary(badge5);
            _badgeDictionaryRepo.AddBadgeToDictionary(badge6);

        }
   }
}
