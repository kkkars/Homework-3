using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._2
{
    public class SortByRank : IComparer<Player>
    {
        public int Compare(Player player1, Player player2)
        {
            return player1.Rank.CompareTo(player2.Rank);
        }
    }

}