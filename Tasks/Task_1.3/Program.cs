using System;
using System.Collections.Generic;

namespace Task_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = default;

            Console.WriteLine("Dictionary with a key (Task 1.3) by Bilotska Karyna");
            Console.WriteLine("To create a dictionary of regions you need to set the amount of elements in the dictionary and after this to fill it with data.\n");

            SetDictionarySize(ref n);

            Dictionary<Region, RegionSettings> regionDictionary = new Dictionary<Region, RegionSettings>(n);

            FillDictionary(ref regionDictionary, n);

            Console.WriteLine();

            foreach (KeyValuePair<Region, RegionSettings> keyValue in regionDictionary)
                Console.WriteLine($"[{keyValue.Key.Brand}, {keyValue.Key.Country}] = [{keyValue.Value.WebSite}]");
        }
        static bool isEmpty(string str)
        {
            if (str.Length == 0)
            {
                Console.WriteLine("Wrong input. Try again\n");
                return true;
            }
            else
                return false;
        }
        static void SetDictionarySize(ref int n)
        {
            bool isCorrect = default;
            do
            {
                Console.Write("Amount of elements N: ");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n > 0)
                        isCorrect = true;
                    else
                    {
                        Console.WriteLine("Wrong input: amount of elements can't ne a zero or less then zero. Try again\n");
                        isCorrect = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Wrong input: amount of elements must be an integer. Try again\n");
                    isCorrect = false;
                }
            } while (!isCorrect);
        }
        static void FillDictionary(ref Dictionary<Region, RegionSettings> regionDictionary, int n)
        {
            bool isCorrect = default;
            for (int i = 0; i < n; i++)
            {
                string brand, country, website;
                isCorrect = false;
                Console.Write("Enter the next values:\n");
                do
                {
                    do
                    {
                        Console.Write("    Brand: ");
                        brand = Console.ReadLine();
                    } while (isEmpty(brand));
                    do
                    {
                        Console.Write("    Country: ");
                        country = Console.ReadLine();
                    } while (isEmpty(country));
                    do
                    {
                        Console.Write("    Website: ");
                        website = Console.ReadLine();
                    } while (isEmpty(website));
                    try
                    {
                        regionDictionary.Add(new Region(brand.ToUpper(), country.ToUpper()), new RegionSettings(website.ToLower()));
                        isCorrect = true;
                    }
                    catch
                    {
                        Console.WriteLine("This is the duplicate. Try again\n");
                        isCorrect = false;
                    }
                } while (!isCorrect);
            }
        }
    }
}
