using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1
{
    public class Inventory
    {
        public string ProductId { get; private set; }
        public string Location { get; private set; }
        public int Balance { get; private set; }

        public Inventory(string productId, string location, int balance)
        {
            ProductId = productId;
            Location = location;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"#{ProductId} - {Location} - {Balance}";
        }
    }
}
