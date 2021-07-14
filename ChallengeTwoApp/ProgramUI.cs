using ChallengeTwoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoApp
{
   public class ProgramUI
    {
        private ClaimRepo _queueOfClaimsRepo = new ClaimRepo();

        public void Run()
        {
            SeedClaims();
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. See All Claims \n" +
                    "2. Take Care Of Next Claim \n" +
                    "3. Enter A New Claim\n" +
                    "10. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "10":
                        Console.WriteLine("Have a nice day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid response. Please try again.");
                        break;
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> claimsInQueue = _queueOfClaimsRepo.ViewListOfClaims();

            ClaimsInQueue(claimsInQueue);
        }

        public void ClaimsInQueue(Queue<Claim> claimsQueue)
        {
            Console.WriteLine($" {"Claim ID"}   {"Description"}        {"Claim Amount"}        {"Date Of Accident"}       {"Date Of Claim"}         {"Is Valid"}\n");
            foreach (Claim claim in claimsQueue)
            {

                Console.WriteLine($"    {claim.ClaimID} --- {claim.Description} --- {claim.ClaimAmount} --- {claim.DateOfIncident} --- {claim.DateOfClaim} --- {claim.IsValid}");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------\n\n");
            }
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here is the next claim in the queue:");

            WritePeekedCalim(_queueOfClaimsRepo.PeekNextClaim());

            Console.WriteLine("Do you want to deal with this claim now (y/n)?");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                Claim dequeuedClaim = _queueOfClaimsRepo.DequeueClaim();
                Console.WriteLine("You Finished Claim: ");
                WritePeekedCalim(dequeuedClaim);
            }
            else
            {
                Console.WriteLine("\nClaim has not been completed. Select an option below to continue....\n\n");
            }
        }

        private void EnterNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            Console.WriteLine("Enter the Claim ID:");
            newClaim.ClaimID = Console.ReadLine();

            Console.WriteLine("Enter the Claim Type:");
            newClaim.ClaimType = Console.ReadLine();

            Console.WriteLine("Enter the Description of the claim:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the Claim Amount:");
            newClaim.ClaimAmount = Console.ReadLine();

            Console.WriteLine("Enter the Date of Incident:");
            newClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter the Date of Claim:");
            newClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Is the claim valid? (y/n)");
            string isValidString = Console.ReadLine().ToLower();
            if (isValidString == "y")
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            _queueOfClaimsRepo.AddClaimToList(newClaim);
        }

        public void WritePeekedCalim(Claim claims)
        {
            Console.WriteLine($"Claim ID: {claims.ClaimID}\n" +
                    $"Claim Type: {claims.ClaimType}\n" +
                    $"Claim Description: {claims.Description}\n" +
                    $"Claim Amount: {claims.ClaimAmount}\n" +
                    $"Date Of Incident: {claims.DateOfIncident}\n" +
                    $"Date Of Claim: {claims.DateOfClaim}\n" +
                    $"Is Valid: {claims.IsValid}\n\n");
        }

        private void SeedClaims()
        {

            Claim claim1 = new Claim("1", "Car", "Car accident on 465.", "$400.00", new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            Claim claim2 = new Claim("2", "Home", "House fire in kitchen", "$4000.00", new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);
            Claim claim3 = new Claim("3", "Theft", "Stolen pancakes", "$4.00", new DateTime(2018, 4, 27), new DateTime(2018, 6, 01), false);
            _queueOfClaimsRepo.AddClaimToList(claim1);
            _queueOfClaimsRepo.AddClaimToList(claim2);
            _queueOfClaimsRepo.AddClaimToList(claim3);
        }
    }
}
