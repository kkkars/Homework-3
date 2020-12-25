using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._2
{
    public class PlayerComparer : IEqualityComparer<Player>
    {
        public bool Equals(Player x, Player y)
        {

            if (Object.ReferenceEquals(x, y))
                return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.FirstName == y.FirstName && x.LastName == y.LastName && x.Age == y.Age && x.Rank == y.Rank;

        }
        public int GetHashCode(Player obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;

            return obj.Age.GetHashCode() ^ obj.FirstName.GetHashCode() ^ obj.LastName.GetHashCode() ^ obj.Rank.GetHashCode();
        }
    }
}
