using System.Collections.Generic;
using System.Linq;

namespace Task_2._1
{
    public class Product
    {
        public string Id { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public decimal Price { get; private set; }

        public List<Tag> Tags { get; set; }

        public Product(string id, string brand, string model, decimal price)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Price = price;
        }

        public override string ToString()
        {
            return $"#{Id} {Brand} - {Model} - ${Price} [{string.Join(", ", Tags.Select(tag => tag.Value).ToArray())}]";
        }

    }
}
