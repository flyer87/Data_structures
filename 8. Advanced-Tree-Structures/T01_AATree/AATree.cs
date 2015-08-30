using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01_AATree
{
    using System;

    public class AATree<TKey, TValue> where TKey : IComparable<TKey>
    {
        public class Node
        {
            internal Node left;
            internal Node right;
            internal int level;
            internal TKey key;
            internal TValue value;

            public Node()
            {
                this.left = this;
                this.right = this;
                this.level = 0;
            }

            public Node(TKey key, TValue value, Node sentinel)
            {
                this.left = sentinel;
                this.right = sentinel;
                this.key = key;
                this.value = value;
                this.level = 1;
            }
        }

        public Node Root
        {
            get
            {
                return this.root;
            }
        }

        private Node root;
        private Node sentinel;
        private Node deleted;

        public AATree()
        {
            root = sentinel = new Node();
            deleted = null;
        }

        public void Skew(ref Node node)
        {
            // right rotation
            if (node.level == node.left.level)
            {
                Node savedNode = node;
                node = savedNode.left;
                savedNode.left = node.right;
                node.right = savedNode;
            }
        }

        public void Split(ref Node node)
        {
            if (node.right.right.level == node.level)
            {
                Node savedNode = node;
                node = savedNode.right;
                savedNode.right = node.left;
                node.left = savedNode;
                node.level++;
            }
        }

        public bool Add(TKey key, TValue value)
        {
            return Insert(ref this.root, key, value);
        }

        public bool Insert(ref Node node, TKey key, TValue value)
        {
            if (node == sentinel)
            {
                node = new Node(key, value, sentinel);
                return true;
            }

            int compResult = key.CompareTo(node.key);
            if (compResult < 0)
            {
                Insert(ref node.left, key, value);
            }
            else if (compResult > 0)
            {
                Insert(ref node.right, key, value);
            }
            else
            {
                return false;
            }

            Skew(ref node);
            Split(ref node);

            return true;
        }

        /// <summary>
        /// Не можах да разбера как се имплементира и затова съм копирал кода от упр.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool Delete(ref Node node, TKey key)
        {
            if (node == sentinel)
            {
                return (deleted != null);
            }

            int compare = key.CompareTo(node.key);
            if (compare < 0)
            {
                if (!Delete(ref node.left, key))
                    return false;
            }
            else
            {
                if (compare == 0)
                    deleted = node;
                if (!Delete(ref node.right, key))
                    return false;
            }

            if (deleted != null)
            {
                deleted.key = node.key;
                deleted.value = node.value;
                deleted = null;
                node = node.right;
            }
            else if (node.left.level < node.level - 1
                  || node.right.level < node.level - 1)
            {
                --node.level;
                if (node.right.level > node.level)
                    node.right.level = node.level;
                Skew(ref node);
                Skew(ref node.right);
                Skew(ref node.right.right);
                Split(ref node);
                Split(ref node.right);
            }

            return true;
        }

        public bool Remove(TKey key)
        {
            return Delete(ref root, key);
        }
    }
}
