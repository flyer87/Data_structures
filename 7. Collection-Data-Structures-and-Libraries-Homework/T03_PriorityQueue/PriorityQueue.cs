using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace T03_PriorityQueue
{
    class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryHeap<T> data;

        public int Count { get; private set; }

        public PriorityQueue(int capacity = 16)
        {
            data = new BinaryHeap<T>(capacity);
            this.Count = this.data.Count;
        }

        public void Enqueue(T item)
        {
            this.data.Add(item);
            this.Count = this.data.Count;
        }

        public T Dequeue()
        {
            var item = this.data.GetPeak();
            this.Count = this.data.Count;

            return item;
        }

        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            foreach (var item in data)
            {
                buffer.AppendLine(item.ToString());
            }

            return buffer.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
