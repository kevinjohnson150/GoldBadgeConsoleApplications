using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoLibrary
{
    public class ClaimRepo
    {
        public Queue<Claim> _queueOfClaimsRepo = new Queue<Claim>();

        // Create
        public void AddClaimToList(Claim claim)
        {
            _queueOfClaimsRepo.Enqueue(claim);
        }

        // Read
        public Queue<Claim> ViewListOfClaims()
        {
            return _queueOfClaimsRepo;
        }

        public Claim PeekNextClaim()
        {
            Claim peekedClaim = _queueOfClaimsRepo.Peek();
            return peekedClaim;
        }

        public Claim DequeueClaim()
        {
            Claim dequeueClaim = _queueOfClaimsRepo.Dequeue();
            return dequeueClaim;
        }

    }
}
