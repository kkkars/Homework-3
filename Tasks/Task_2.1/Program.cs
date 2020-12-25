using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Task_2._1.Menu;

namespace Task_2._1
{
    class Program
    {
        private static List<Product> products = new List<Product>();
        private static List<Tag> tags = new List<Tag>();
        private static List<Inventory> inventories = new List<Inventory>();

        static void Main(string[] args)
        {
            ShowInformation();

            LoadTagsData();
            LoadProductsData();
            LoadInventoryData();

            StartMenu();
        }

        private static void LoadProductsData()
        {
            try
            {
                var productLines = File.ReadAllLines("Products.txt");
                products.AddRange(productLines.ToList().Skip(1).Select(productString =>
                {
                    string[] productValues = productString.Split(new char[] { ';' });

                    Product product = new Product(productValues[0], productValues[1], productValues[2], Convert.ToDecimal(productValues[3]));
                    product.Tags = tags.Where(tag => tag.ProductId == productValues[0]).ToList();
                    return product;
                }).ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Environment.Exit(-1);
            }
        }
        private static void LoadTagsData()
        {
            try
            {
                var tagLines = File.ReadAllLines("Tags.txt");
                tags.AddRange(tagLines.ToList().Skip(1).Select(tagString =>
                {
                    string[] tagValues = tagString.Split(new char[] { ';' });
                    return new Tag(tagValues[0], tagValues[1]);
                }).ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Environment.Exit(-1);
            }
        }
        private static void LoadInventoryData()
        {
            try
            {
                var inventoryLines = File.ReadAllLines("Inventory.txt");

                inventories.AddRange(inventoryLines.ToList().Skip(1).Select(inventoryString =>
                {
                    string[] inventoryValues = inventoryString.Split(new char[] { ';' });
                    return new Inventory(inventoryValues[0], inventoryValues[1], Convert.ToInt32(inventoryValues[2]));
                }).ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Environment.Exit(-1);
            }
        }

        public static void StartMenu()
        {
            bool isCorrect = default;
            string option = default;

            do
            {
                ShowMenu();
                GetOption(ref option);
                if (option == "1")
                {
                    Environment.Exit(0);
                }
                else
                if (option == "2")
                {
                    ProductMenu(products);
                }
                else
                if (option == "3")
                {
                    RemainsMenu(inventories);
                }
                else
                {
                    Console.WriteLine("Wrong option. Try again");
                    isCorrect = false;
                }

            } while (!isCorrect);
        }
        public static void ShowInformation()
        {
            Console.WriteLine("ERP Reports Bot (Task 1.4) by Bilotska Karyna\n");
            Console.WriteLine("With a help of this bot you can see different reports about the remains at all warehouses.\nChoose the option to run the command\n");
        }
        
    }
}
