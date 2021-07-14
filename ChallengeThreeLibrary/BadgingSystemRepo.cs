using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeLibrary
{
    class BadgingSystemRepo
    {
        Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        //Create
        public void AddBadgeToDictionary (BadgingSystem badge)
        {
            _badgeDictionary.Add(badge.BadgeID, badge.DoorNames);
        }

        //Read
        public Dictionary<int, List<BadgingSystem>> GetBadgeList()
        {
            
        }
    }
}
