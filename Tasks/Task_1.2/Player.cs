using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._2
{
    public class Player : IPlayer
    {

        private int age;
        private string firstName;
        private string lastName;
        private PlayerRank rank;

        public Player(int age, string firstName, string lastName, PlayerRank rank)
        {
            this.age = age;
            this.firstName = firstName;
            this.lastName = lastName;
            this.rank = rank;
        }

        public int Age => age;
        public string FirstName => firstName;
        public string LastName => lastName;
        public PlayerRank Rank => rank;

        public override string ToString()
            => $"Last name: {lastName}   First name: {firstName}  Age: {age}  Rank:  {rank}\n";
    }
}
