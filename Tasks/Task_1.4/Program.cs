using System;
using System.Collections.Generic;

namespace Task_1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<BracketWithIndex> brackets = new Stack<BracketWithIndex>();

            string userInput = default;
            bool hasBrackets = default;
            int positionOfMistake = default;

            Console.WriteLine("Check pairing brackets (Taks 1.4) by Bilotska Karyna\n");
            Console.Write("Program checks next types of pairing brackets to have a pair:\n    < or >\n    { or }\n    ( or )\n    [ or ]\nEnter the expression that contains any of those brackets to check:\n\n");

            CheckInput(ref userInput, ref hasBrackets);
            ShowResult(ref userInput, ref brackets, ref positionOfMistake);
        }

        static bool isOpen(char bracket)
        {
            return bracket == '(' || bracket == '{' || bracket == '[' || bracket == '<';
        }
        static bool isClosed(char bracket)
        {
            return bracket == ')' || bracket == '}' || bracket == ']' || bracket == '>';
        }
        static bool isPair(BracketWithIndex oBracket, char cBracket)
        {
            return (cBracket - oBracket.Bracket) >= 1 && (cBracket - oBracket.Bracket) <= 2;
        }
        static bool isCorrect(ref Stack<BracketWithIndex> brackets, string input, ref int positionOfMistake)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (isOpen(input[i]))
                {
                    brackets.Push(new BracketWithIndex(i, input[i]));
                }
                else
                if (brackets.Count != 0 && isClosed(input[i]))
                {
                    if (isPair(brackets.Peek(), input[i]))
                    {
                        brackets.Pop();
                    }
                    else
                    {
                        positionOfMistake = i;
                        brackets.Clear();
                        return false;
                    }
                }
                else
                if (brackets.Count == 0 && isClosed(input[i]))
                {
                    positionOfMistake = i;
                    brackets.Clear();
                    return false;
                }
            }
            return brackets.Count == 0;
        }

        static void CheckInput(ref string userInput, ref bool hasBrackets)
        {
            do
            {
                Console.Write("Expression: ");
                userInput = Console.ReadLine();
                hasBrackets = userInput.Contains('(') || userInput.Contains(')') ||
                                   userInput.Contains('{') || userInput.Contains('}') ||
                                   userInput.Contains('[') || userInput.Contains(']') ||
                                   userInput.Contains('<') || userInput.Contains('>');
                if (!hasBrackets)
                {
                    Console.WriteLine("Wrong input. Try again\n");
                }
            } while (!hasBrackets);
        }
        static void ShowResult(ref string userInput, ref Stack<BracketWithIndex> brackets, ref int positionOfMistake)
        {
            if (isCorrect(ref brackets, userInput, ref positionOfMistake))
                Console.WriteLine("Everything is correct!\n");
            else
            {
                if (brackets.Count != 0)
                    positionOfMistake = brackets.Peek().Index;

                Console.Write("Mistake: ");
                if (isOpen(userInput[positionOfMistake]))
                    Console.WriteLine($"{userInput[positionOfMistake]} at position {positionOfMistake} does not have a close bracket\n");
                else
                    if (isClosed(userInput[positionOfMistake]))
                    Console.WriteLine($"{userInput[positionOfMistake]} at position {positionOfMistake} does not have an open bracket\n");
            }
        }
    }

}
