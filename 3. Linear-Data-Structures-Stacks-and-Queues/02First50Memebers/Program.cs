using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int numberOfMembers = 50;
        int firstMember = Int32.Parse(Console.ReadLine());

        Queue<int> numberQueue = new Queue<int>();
        numberQueue.Enqueue(firstMember);
        int cntPrintedNumbers = 0;

        while (numberQueue.Count > 0)
        {
            int currentItem = numberQueue.Dequeue();
            Console.Write("{0}, ", currentItem);
            cntPrintedNumbers++;

            if (cntPrintedNumbers == numberOfMembers)
            {
                break;
            }

            numberQueue.Enqueue(currentItem + 1);
            numberQueue.Enqueue(2 * currentItem + 1);
            numberQueue.Enqueue(currentItem + 2);
        }
    }
}