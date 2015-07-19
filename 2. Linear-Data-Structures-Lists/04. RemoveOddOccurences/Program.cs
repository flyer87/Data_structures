using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RemoveOddOccurences
{
    class Program
    {
        static List<int> RemoveOddOccur(List<int> numbers)
        {
            List<int> numbersCnt = Enumerable.Repeat(0, 1000).ToList();
           // Dictionary<int, int> numbersCnt = new Dictionary<int, int>();

            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    if (numbersCnt.ContainsKey(numbers[i]))
            //    {
            //        numbersCnt[numbers[i]]++;
            //    }
            //    else
            //    {
            //        numbersCnt[numbers[i]] = 1;
            //    }
            //}

            for (int i = 0; i < numbers.Count; i++)
            {
                numbersCnt[numbers[i]]++;
            }

            //numbers = new List<int>();
            //foreach (KeyValuePair<int, int> item in numbersCnt)
            //{
            //    if (item.Value % 2 == 0)
            //    {                                      
            //        numbers.Add(item.Key);
            //    }
            //}

            for (int i = 0; i < numbersCnt.Count; i++)
            {
                if ((numbersCnt[i] % 2 != 0) && (numbersCnt[i] != 0))
                {
                    numbers.RemoveAll(w => w == i);
                }
            }

            return numbers;
        }

        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            List<int> numbers = new List<int>();
            numbers = line.Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();

            Console.WriteLine(String.Join(" ", RemoveOddOccur(numbers)));
        }
    }
}
