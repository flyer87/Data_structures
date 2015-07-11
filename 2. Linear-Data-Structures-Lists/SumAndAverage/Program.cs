using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        String line = Console.ReadLine();
        //numbers = line.Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList().Select(Int32.Parse).ToList<int>();
        if (!String.IsNullOrWhiteSpace(line))
        {
            numbers = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();        
            Console.WriteLine("Sum= {0}; Avegare= {1}", numbers.Sum(), numbers.Average());            
        }
        else
        {
            Console.WriteLine("Sum= {0}; Avegare= {1}", 0, 0);            
        }
    }
}

