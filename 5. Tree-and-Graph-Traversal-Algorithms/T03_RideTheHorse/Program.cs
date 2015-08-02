using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T03_RideTheHorse
{
    class Program
    {
        static int[,] chess;
        static Queue<Position> queue;
        static int startX;
        static int startY;
        static int width;
        static int height;

        static void PlayAllHorseMovements()
        {            
            
            chess = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    chess[i, j] = 0;
                }                
            }            
            chess[startY, startX]++;

            var startPosition = new Position() { X = startX, Y = startY };            
            queue = new Queue<Position>();
            queue.Enqueue(startPosition);
            while (queue.Count > 0)
            {
                var currentPos = queue.Dequeue();
                TryDirection(queue, currentPos, +1, -2);
                TryDirection(queue, currentPos, -1, -2);
                TryDirection(queue, currentPos, +2, -1);
                TryDirection(queue, currentPos, +2, +1);
                TryDirection(queue, currentPos, +1, +2);
                TryDirection(queue, currentPos, -1, +2);
                TryDirection(queue, currentPos, -2, +1);
                TryDirection(queue, currentPos, -2, -1);
            }
        }

        static void TryDirection(Queue<Position> queue, Position currentPos, int deltaX, int deltaY)
        {
            int newX = currentPos.X + deltaX;
            int newY = currentPos.Y + deltaY;
            if (newX >= 0 && newX < width && newY >= 0 && newY < height
                && chess[newY, newX] == 0)
            {
                chess[newY, newX] = (chess[currentPos.Y, currentPos.X] + 1);
                Position newPos = new Position()
                {
                    X = newX,
                    Y = newY
                };

                queue.Enqueue(newPos);
            }
        }

        static void Main(string[] args)
        {
            height = int.Parse(Console.ReadLine());
            width = int.Parse(Console.ReadLine());
            startY = int.Parse(Console.ReadLine());
            startX = int.Parse(Console.ReadLine());

            PlayAllHorseMovements();

            for (int i = 0; i < height; i++)
            {
                Console.WriteLine(chess[i, width / 2]);
            }

            // print matrix
            //for (int i = 0; i < height; i++)
            //{
            //    for (int j = 0; j < width; j++)
            //    {
            //        Console.Write(" " + chess[i, j]);
            //    }
            //    Console.Write("\n");
            //}            
        }
    }
}
