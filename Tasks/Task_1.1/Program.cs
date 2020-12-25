using System;
using System.Linq;

namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numberSequence = default;

            Console.WriteLine("Statistics on array LINQ (Task 1.1) by Bilotska Karyna\n\n");
            Console.WriteLine("Enter the number sequence, separated by commas to get following statistics:\n    Minimum element\n    Maximum element\n    Sum of all elements\n    Average\n    Standard deviation\n\n ");

            GetUserInput(ref numberSequence);

            int min = numberSequence.Select(x => int.Parse(x)).Min();
            int max = numberSequence.Select(x => int.Parse(x)).Max();
            int sum = numberSequence.Select(x => int.Parse(x)).Sum();
            double average = (double)sum / numberSequence.Length;
            double standardDeviation = Math.Sqrt(numberSequence.Select(x => double.Parse(x)).Select(x => Math.Pow((x - average), 2)).Sum() / average);

            Console.WriteLine($"\nStatistics:\n    Minimum element: {min}\n    Maximum element: {max}\n    Sum: {sum}\n    Average: {average}\n    Standard deviation: {standardDeviation}");
            Console.WriteLine("\nUnique elements, sorted in ascending order: ");
            var uniqueSortedNumbers = numberSequence.OrderBy(x => x).Distinct();

            foreach (var i in uniqueSortedNumbers)
                Console.Write(i + " ");
        }
        static void GetUserInput(ref string[] numberSequence)
        {
            bool isCorrect = default;
            string userInput;
            do
            {
                Console.WriteLine("Enter series of integer: ");
                userInput = Console.ReadLine();
                numberSequence = userInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (numberSequence.All(x => int.TryParse(x, out _)) && numberSequence.Length != 0 && !(userInput.Any(x => x.Equals('+'))))
                {
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("Wrong input. Try again\n");
                    isCorrect = false;
                }
            } while (!isCorrect);
        }
    }
}
