using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02_RoundRace
{
    class Program
    {
        static Dictionary<int, List<int>> friendsTree;
        static int maxLength = 0;
        static int leader;

        static void Main(string[] args)
        {
            ReadInput();
            FindLongestPathFromNodeDFS(leader);
            Console.WriteLine(maxLength);
        }

        static void FindLongestPathFromNodeDFS(int node, int length = 1)
        {
            if (length > maxLength)
            {
                maxLength = length;
            }
            
            if (friendsTree.ContainsKey(node))
            {
                length++;
                foreach (var child in friendsTree[node])
                {
                    FindLongestPathFromNodeDFS(child, length);
                }
            }
        }

        static void ReadInput()
        {
            int cntOfFriendships = int.Parse(Console.ReadLine());
            leader = Int16.Parse(Console.ReadLine());

            friendsTree = new Dictionary<int, List<int>>();
            for (int i = 1; i <= cntOfFriendships; i++)
            {
                int[] friends = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (!friendsTree.ContainsKey(friends[0]))
                {
                    friendsTree[friends[0]] = new List<int>();
                }

                friendsTree[friends[0]].Add(friends[1]);
            }
        }
    }
}
