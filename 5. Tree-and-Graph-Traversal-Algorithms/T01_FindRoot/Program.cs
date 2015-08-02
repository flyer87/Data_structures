using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01_FindRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int cntEdges = int.Parse(Console.ReadLine());
            bool[] hasParent = new bool[cntEdges + 1];
            HashSet<int> cntNodes = new HashSet<int>();
            for (int edge = 0; edge < cntEdges; edge++)
            {
                var edgeItems = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var child = edgeItems[1];
                cntNodes.Add(child);
                hasParent[child] = true;
            }

            int cntOfRoots = 0;
            int root = 0;
            for (int node = 0; node < cntNodes.Count; node++)
            {
                if (hasParent[node] == false)
                {
                    cntOfRoots++;
                    root = node;
                }
            }

            if (cntOfRoots == 0)
            {
                Console.WriteLine("No root!");
            }

            if (cntOfRoots == 1)
            {
                Console.WriteLine(root);
            }

            if (cntOfRoots > 1)
            {
                Console.WriteLine("Forest is not a tree!");
            }


            //int cntEdges = int.Parse(Console.ReadLine());
            //int[] hasParent = Enumerable.Repeat(-1, cntEdges + 1).ToArray();
            //for (int edge = 0; edge < cntEdges; edge++)
            //{
            //    var edgeItems = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //    var child = edgeItems[1];
            //    hasParent[child] = 1;
            //}

            //int cntOfRoots = 0;
            //int root = 0;
            //for (int node = 0; node < hasParent.Length; node++)
            //{
            //    if (hasParent[node] == 1)
            //    {
            //        cntOfRoots++;
            //        root = node;
            //    }
            //}

            //if (cntOfRoots == 0)
            //{
            //    Console.WriteLine("No root!");
            //}

            //if (cntOfRoots == 1)
            //{
            //    Console.WriteLine(root);
            //}

            //if (cntOfRoots > 1)
            //{
            //    Console.WriteLine("Forest is not a tree!");
            //}


        }
    }
}