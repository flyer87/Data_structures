using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01_FindRoot
{
    public class Tree<T>
    {
        public T Value { get; set; }
        public IList<Tree<T>> Children { get; set; }
        private Dictionary<int, List<int>> nodeByValue;

        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.Children.Add(child);
            }
        }
    }
}
