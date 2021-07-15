using ChallengeTwoLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeTwoTests
{
    [TestClass]
    public class ClaimRepoTests
    {
        private ClaimRepo _repo;
        private Claim _claims;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepo();
            _claims = new Claim("15", "Car", "Accident on 116th Street", "$500.00", new DateTime(2021, 07, 14), new DateTime(2021, 07, 15), true);

            _repo.AddClaimToList(_claims);
        }

        [TestMethod]
        public void AddClaimToList_ShouldNotGetNull()
        {
            Claim claim = new Claim();
            claim.ClaimID = "15";
            ClaimRepo repository = new ClaimRepo();

            repository.AddClaimToList(claim);
            Claim claimFromDirectory = repository.PeekNextClaim();

            Assert.IsNotNull(claimFromDirectory);
        }

        [TestMethod]
        public void DequeueClaim_ShouldRemoveClaim()
        {
            Claim dequeueClaim = _repo.DequeueClaim();
            Assert.AreEqual(dequeueClaim, _claims);
        }

        [TestMethod]
        public void PeekClaim_ShouldPeekNextClaim()
        {
            Claim peekClaim = _repo.PeekNextClaim();
            Assert.AreEqual(peekClaim, _claims);
        }
    }
}
