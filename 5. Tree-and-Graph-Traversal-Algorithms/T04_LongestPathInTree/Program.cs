using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T04_LongestPathInTree
{
    class Program
    {
        static int cntOfNodes;
        static int cntOfEdges;
        static Dictionary<int, IList<int>> nodeChildrens;
        static Dictionary<int, int?> childParent;

        static void Main(string[] args)
        {
            ReadInput();
            FindBiggerSum();

            

            

            
        }
        
        /// <summary>
        /// NE E TOWARSHENA!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        /// 







        HashSet<int> t;







        static SortedList<int, int> sumList = new SortedList<int, int>();

        static int FindBiggerSum()
        {
            //for (int node = 0; node < nodeChildrens.Count; node++)
            foreach (var node in nodeChildrens)
            {                
                if (node.Value.Count == 0)
                {
                    // up to the root
                    int sum = 0;
                    //for (int child = 0; child < childParent.Count; child++)
                    foreach (var child in childParent)
                    {
                        sum += child.Key;
                        int parent = (int)child.Value;
                        bool rootnotreached = true;
                        while (rootnotreached)
                        {
                            sum += parent; 
                           
                            //int? value;
                            //if (childParent.TryGetValue((int)childParent[child], out value))
                            //{
                            //    parent = (int)childParent[parent];
                            //}
                            //else
                            //{
                            //    rootnotreached = false;
                            //}

                        }            
                    }

                    sumList.Add(sum, 0);

                }
            }

            int finalSum = 0;
            for (int i = 1; i <= 2; i++)
            {
                finalSum += sumList.Keys[i];
            }

            return finalSum;
        }

        static void ReadInput()
        {
            cntOfNodes = int.Parse(Console.ReadLine());
            cntOfEdges = int.Parse(Console.ReadLine());

            nodeChildrens = new Dictionary<int, IList<int>>();
            childParent = new Dictionary<int, int?>();
            for (int i = 0; i < cntOfEdges; i++)
            {
                string[] edge = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int parentValue = int.Parse(edge[0]);
                int childValue = int.Parse(edge[1]);
                
                if (!nodeChildrens.ContainsKey(parentValue))
                {
                    nodeChildrens[parentValue] = new List<int>();
                }

                if (nodeChildrens.ContainsKey(parentValue))
                {
                    nodeChildrens[parentValue].Add(childValue);
                }

                if (!nodeChildrens.ContainsKey(childValue))
                {
                    nodeChildrens[childValue] = new List<int>();
                }              
                             
                childParent[childValue] = parentValue;               
                if (!childParent.ContainsKey(parentValue))
                {
                    childParent[parentValue] = null;
                }
            }
        }
    }
}
