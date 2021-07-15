using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeLibrary
{
    public class BadgingSystemRepo
    {
        Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        
        //Create
        public bool AddBadgeToDictionary (BadgingSystem badge)
        {
            if(badge is null)
            {
                return false;
            }

            _badgeDictionary.Add(badge.BadgeID, badge.DoorNames);

            return true;
        }

        //Read
        public Dictionary<int, List<string>> GetBadgeList()
        {
            foreach (var content in _badgeDictionary)
            {
                return _badgeDictionary;
            }
            return null;
        }

        //Delete


        //Helper Method
        public BadgingSystem GetBadgeByID(int badgeID)
        {
            foreach (var content in _badgeDictionary)
            {
                if (content.Key == badgeID)
                {
                    return new BadgingSystem(content.Key, content.Value);
                }
            }
            return null;
        }

        public string GetDoor (string doorName)
        {
            foreach (var content in _badgeDictionary)
            {
                foreach (var item in content.Value)
                {
                    if (item == doorName)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
    }
}
