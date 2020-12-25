using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._2
{
    public class SortByFullName : IComparer<Player>
    {
        public int Compare(Player player1, Player player2)
        {
            string FullName1 = player1.LastName + " " + player1.FirstName;
            string FullName2 = player2.LastName + " " + player2.FirstName;
            return FullName1.CompareTo(FullName2);
        }
    }
}
