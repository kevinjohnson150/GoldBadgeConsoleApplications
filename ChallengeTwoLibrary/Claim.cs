using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoLibrary
{
    public class Claim
    {
        public string ClaimID { get; set; }

        public string ClaimType { get; set; }

        public string Description { get; set; }

        public string ClaimAmount { get; set; }

        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }

        public bool IsValid { get; set; }

        public Claim() { }

        public Claim(string claimID, string claimType, string description, string claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            this.ClaimID = claimID;
            this.ClaimType = claimType;
            this.Description = description;
            this.ClaimAmount = claimAmount;
            this.DateOfIncident = dateOfIncident;
            this.DateOfClaim = dateOfClaim;
            this.IsValid = isValid;
        }

    }
}
