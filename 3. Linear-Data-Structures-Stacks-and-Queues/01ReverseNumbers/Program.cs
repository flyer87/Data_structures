using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string line = Console.ReadLine();
        int[] numbers = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).
            Select(Int32.Parse).ToArray();

        Stack<int> reverseStack = new Stack<int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            reverseStack.Push(numbers[i]);
        }

        while (reverseStack.Count > 0)
        {
            Console.Write("{0} ", reverseStack.Pop());
        }

        Console.WriteLine();
    }
}

