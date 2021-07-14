using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeLibrary
{
    public class BadgingSystem
    {
        public int BadgeID { get; set; }

        public List<string> DoorNames { get; set; }

        public BadgingSystem() { }

        public BadgingSystem(int badgeID, List<string> doorNames)
        {
            this.BadgeID = badgeID;
            this.DoorNames = doorNames;
        }
    }
}
