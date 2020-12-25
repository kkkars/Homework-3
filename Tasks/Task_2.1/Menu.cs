using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_2._1
{
    public class Menu
    {

        public static void ShowMenu(int sublevel = 0)
        {
            Console.Write("\n1.Exit\n2.Products\n");
            if (sublevel == 1)
                Console.Write("    a.Go to main menu\n    b.Search product\n    c.See all products(In ascending order)\n    d.See all products(In descending order)\n");
            Console.Write("3.Remains\n");
            if (sublevel == 2)
                Console.WriteLine("    a.Go to main menu\n    b.Ended products\n    c.Remains(In ascending order)\n    d.Remains(In descending order)\n    e.Remains by ID\n");

        }
        public static void ProductMenu(List<Product> products)
        {
            string option = default;
            do
            {
                ShowMenu(1);
                GetOption(ref option);
                if (option.ToLower() == "a")
                {
                    return;
                }
                else
                if (option.ToLower() == "b")
                {
                    Console.Write("Enter search query: ");
                    string searchQuery = Console.ReadLine();
                    DrawList(SearchProducts(products, searchQuery));
                }
                else
                if (option.ToLower() == "c")
                {
                    DrawList(GetProducts(products));
                }
                else
                if (option.ToLower() == "d")
                {
                    DrawList(GetProducts(products, false));
                }
                else
                {
                    Console.WriteLine("Wrong input. Try again\n");
                }
            } while (true);
        }
        public static void RemainsMenu(List<Inventory> inventories)
        {
            string option = default;
            do
            {
                ShowMenu(2);
                GetOption(ref option);

                if (option.ToLower() == "a")
                {
                    return;
                }
                else
                if (option.ToLower() == "b")
                {
                    DrawList(GetAbsentProducts(inventories));
                }
                else
                if (option.ToLower() == "c")
                {
                    DrawList(GetRemains(inventories));
                }
                else
                if (option.ToLower() == "d")
                {
                    DrawList(GetRemains(inventories, false));
                }
                else
                if (option.ToLower() == "e")
                {
                    Console.Write("Enter search query: ");
                    string searchQuery = Console.ReadLine();
                    DrawList(SearchRemains(inventories, searchQuery));
                }
                else
                {
                    Console.WriteLine("Wrong input. Try again\n");
                }
            } while (true);
        }

        private static List<Product> GetProducts(List<Product> products, bool isAscending = true)
        {
            if (isAscending)
            {
                return products.OrderBy(product => product.Price).ToList();
            }
            else
            {
                return products.OrderByDescending(product => product.Price).ToList();
            }
        }
        private static List<Product> SearchProducts(List<Product> products, string searchString)
        {
            return products.Where(product => product.Id.ToLower().Contains(searchString.ToLower())
            || product.Model.ToLower().Contains(searchString.ToLower())
            || product.Brand.ToLower().Contains(searchString.ToLower())
            || product.Tags.Any(tag => tag.Value.ToLower().Contains(searchString.ToLower())))
                .Distinct(new ProductComparer())
                .ToList();
        }
        private static List<Inventory> GetAbsentProducts(List<Inventory> inventories)
        {
            return inventories.Where(inventory => inventory.Balance == 0).ToList();
        }
        private static List<Inventory> GetRemains(List<Inventory> inventories, bool isAscending = true)
        {
            var outputInventories = new List<Inventory>();
            if (isAscending)
            {
                return inventories.OrderBy(inventory => inventory.Balance).ToList();
            }
            else
            {
                return inventories.OrderByDescending(inventory => inventory.Balance).ToList();
            }
        }
        private static List<Inventory> SearchRemains(List<Inventory> inventories, string productId)
        {
            return inventories.Where(inventory => inventory.ProductId.ToLower().Equals(productId.ToLower())).OrderByDescending(inventory => inventory.Balance).ToList();
        }

        private static void DrawList<T>(List<T> inputList)
        {
            if (inputList.Any())
            {
                foreach (var inputItem in inputList)
                {
                    Console.WriteLine(inputItem.ToString());
                }
            }
            else
            {
                Console.WriteLine("There is no items");
            }
        }
        public static void GetOption(ref string option)
        {
            Console.Write("\nOption: ");
            option = Console.ReadLine();
        }
    }
}
