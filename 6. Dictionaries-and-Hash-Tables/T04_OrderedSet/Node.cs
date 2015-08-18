using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T04_OrderedSet
{
    public class Node<T> : IEnumerable<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> SmallChild { get; set; }
        public Node<T> BigChild { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }

        //public override bool Equals(object obj)
        //{
        //    Node<T> other = obj as Node<T>;
        //    if (other != null)
        //    {
        //        if (this.Value.Equals(other.Value))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        public IEnumerator<T> GetEnumerator()
        {
            if (this.SmallChild != null)
            {
                foreach (var v in this.SmallChild)
                {
                    yield return v;
                }
                
            }

            yield return Value;

            if (this.BigChild != null)
            {
                foreach (var v in this.BigChild)
                {
                    yield return v;
                }                
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
