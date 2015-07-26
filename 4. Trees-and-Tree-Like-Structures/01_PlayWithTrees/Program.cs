using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_PlayWithTrees;

namespace _01_PlayWithTrees
{
    class Program
    {
        static void Main()
        {
            Tree<int> corner = new Tree<int>(0);
            int nodeCnts = int.Parse(Console.ReadLine());
            for (int i = 0; i < nodeCnts - 1; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);
                Tree<int> parentNode = Tree<int>.GetTreeNodeByValue(parentValue);
                int childValue = int.Parse(edge[1]);
                Tree<int> childNode = Tree<int>.GetTreeNodeByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
                if (i == 0)
                {
                    corner = parentNode;
                }
            }

            int pathSum = int.Parse(Console.ReadLine());
            int subTreeSum = int.Parse(Console.ReadLine());

            Console.WriteLine();
            corner.Print();
            
        }

        
    }
}
