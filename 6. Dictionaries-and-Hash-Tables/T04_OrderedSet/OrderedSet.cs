using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T04_OrderedSet
{
    public class OrderedSet<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node<T> rootNode;

        public void Add(T value)
        {            
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value");
            }

            if (!this.Contains(value))
            {
                this.Count++;
            }

            this.rootNode = Insert(value, rootNode, null);
        }

        public bool Contains(T value)
        {
            var foundNode = FindNode(value); 

            if (foundNode != null)
            {
                return true;
            }

            return false;
        }

        private Node<T> FindNode(T value)
        {
            Node<T> currentNode = this.rootNode;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    break;
                }

                if (value.CompareTo(currentNode.Value) <= 0)
                {
                    currentNode = currentNode.SmallChild;
                }
                else
                if (value.CompareTo(currentNode.Value) > 0)
                {
                    currentNode = currentNode.BigChild;
                }
            }

            return currentNode;
        }

        public void Remove(T value)
        {
            var nodeToRemove = FindNode(value);
            if (nodeToRemove != null)
            {
                // get the childrens' value of the node to be deleted
                List<T> childrensValue = new List<T>();
                childrensValue = GetChildrensValues(nodeToRemove, childrensValue);

                if (nodeToRemove.Value.CompareTo(nodeToRemove.Parent.Value) <= 0)
                {
                    nodeToRemove.Parent.SmallChild = null;
                }
                else
                {
                    nodeToRemove.Parent.BigChild = null;
                }

                this.Count--;

                // add them again 
                foreach (var itemValue in childrensValue)
                {
                    this.Add(itemValue);
                }
            }
            else
            {
                throw new ArgumentException();
            }
                             
        }

        private List<T> GetChildrensValues(Node<T> node, List<T> list)
        {
            if (node.BigChild != null)
            {
                list.Add(node.BigChild.Value);
                list = GetChildrensValues(node.BigChild, list);
            }

            if (node.SmallChild != null)
            {
                list.Add(node.SmallChild.Value);
                list = GetChildrensValues(node.SmallChild, list);
            }

            return list;
        }

        private Node<T> Insert(T value, Node<T> node, Node<T> parent)
        {
            if (node == null)
            {
                node = new Node<T>(value);
                node.Parent = parent;
            }
            else
            {
                if (value.CompareTo(node.Value) < 0)
                {
                    node.SmallChild = Insert(value, node.SmallChild, node);
                }
                else if (value.CompareTo(node.Value) > 0)
                {
                    node.BigChild =   Insert(value, node.BigChild, node);
                }
            }

            return node;
        }

        public int Count { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return this.rootNode.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
