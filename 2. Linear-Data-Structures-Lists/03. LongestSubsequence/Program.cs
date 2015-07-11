using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    /* NOT FINISHED, DON'T TEST!*/

    static List<int> Longest(List<int> list)
    {
        int longestNum = list[0];
        int longestCnt = 0;
        for (int i = 0; i < list.Count-1; i++)
        {
            int cnt = 0;
            longestNum = list[i];
            if (list[i] == longestNum)
            {
                cnt++;
            }            
        }

        return new List<int>();
    }

    static void Main(string[] args)
    {
        Longest(new List<int>(){ 2, 2, 2 });
    }
}