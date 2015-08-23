using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T03_PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            //var queue = new PriorityQueue<int>();
            //queue.Enqueue(99);
            //queue.Enqueue(2);
            //queue.Enqueue(10);
            //queue.Enqueue(25);
            //queue.Enqueue(11);
            //queue.Enqueue(3);
            //queue.Enqueue(7);
            //queue.Enqueue(22);
            //queue.Enqueue(5);
            //queue.Enqueue(1);
            //queue.Enqueue(45);
            //queue.Enqueue(31);

            var queue = new PriorityQueue<Student>();

            queue.Enqueue(new Student() { Name = "Ivan", Age = 27 });
            queue.Enqueue(new Student() { Name = "Pesho", Age = 21 });
            queue.Enqueue(new Student() { Name = "Dragan", Age = 24 });
            queue.Enqueue(new Student() { Name = "Gosho", Age = 18 });
            queue.Enqueue(new Student() { Name = "Todor", Age = 25 });

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue().ToString());
            }
        }
    }
}

