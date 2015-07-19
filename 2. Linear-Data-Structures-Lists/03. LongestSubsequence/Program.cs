using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    /* NOT FINISHED, DON'T TEST!*/

    static List<int> Longest(List<int> numbersList)
    {
        int longestNumb = 0; 
        int longestCnt = 0;

        int cnt = 1;
        int currntNum = numbersList[0];

        for (int i = 0; i < numbersList.Count-1; i++)
        {
            if (numbersList[i + 1] == currntNum)
            {
                cnt++;
            }
            else
            {
                if (cnt > longestCnt)
                {
                    longestNumb = currntNum;
                    longestCnt = cnt;
                    currntNum = numbersList[i + 1];
                    cnt = 1;
                }
            }
        }

        if ((numbersList[numbersList.Count-1] == currntNum) && (cnt > longestCnt))
        {
            longestNumb = currntNum;
            longestCnt = cnt;            
        }

        var list1 = new List<int>();
        for (int i = 0; i < longestCnt; i++)
        {
            list1.Add(longestNumb);
        }

        return list1;
    }

    static void Main(string[] args)
    {
        var line = Console.ReadLine();
        List<int> numbers = new List<int>();
        numbers = line.Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();
        Console.WriteLine(String.Join(" ", Longest(numbers)));
    }
}