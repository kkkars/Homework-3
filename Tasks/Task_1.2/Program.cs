using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Three sorts and one comparator (Task 1.2) by Bilotska Karyna\n");

            List<Player> players = new List<Player>()
            {
               new Player(29, "Ivan", "Ivanenko", PlayerRank.Captain),
               new Player(19, "Peter", "Petrenko", PlayerRank.Private),
               new Player(59, "Ivan", "Ivanov", PlayerRank.General),
               new Player(52, "Ivan", "Snezko", PlayerRank.Lieutenant),
               new Player(34, "Alex", "Zeshko", PlayerRank.Colonel),
               new Player(29, "Ivan", "Ivanenko", PlayerRank.Captain),//duplicate
               new Player(19, "Peter","Petrenko", PlayerRank.Private), //duplicate
               new Player(34, "Vasiliy", "Sokol", PlayerRank.Major),
               new Player(31, "Alex", "Alexeenko", PlayerRank.Major)
            };

            players = players.Distinct(new PlayerComparer()).ToList();

            Console.WriteLine("List, sorted by First name and Last name\n\n");
            players.Sort(new SortByFullName());
            players.ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine("\nList, sorted by Age\n\n");
            players.Sort(new SortByAge());
            players.ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine("\nList, sorted by Rank\n\n");
            players.Sort(new SortByRank());
            players.ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
