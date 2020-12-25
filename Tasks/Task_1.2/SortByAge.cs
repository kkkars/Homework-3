using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._2
{
    class SortByAge : IComparer<Player>
    {
        public int Compare(Player player1, Player player2)
        {
            return player1.Age.CompareTo(player2.Age);
        }
    }
}