using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_PlayWithTrees
{
    public class Tree<T>
    {
        public T Value { get; set; }
        public Tree<T> Parent { get; set; }
        public IList<Tree<T>> Children { get; set; }
        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.Children.Add(child);
                child.Parent = this;
            }
        }

        public void Print(int indent = 0)
        {
            Console.Write(new String(' ', 2 * indent));
            Console.WriteLine(this.Value);
            foreach (var child in this.Children)
            {
                child.Print(indent + 1);
            }
        }

        static Dictionary<T, Tree<T>> nodeByValue = new Dictionary<T, Tree<T>>();

        public static Tree<T> GetTreeNodeByValue(T value){
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<T>(value);
            }

            return nodeByValue[value];
        }

        public static Tree<T> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(node => node.Parent == null);

            return rootNode;
        }

        public static IList<Tree<T>> FindMiddlenodes()
        {
            var middleNodes = nodeByValue.Values.Where(node => node.Children.Count > 0 && node.Parent != null).ToList();

            return middleNodes;
        }
    }
}
