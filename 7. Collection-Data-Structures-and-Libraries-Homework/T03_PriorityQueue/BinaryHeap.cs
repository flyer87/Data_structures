using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T03_PriorityQueue
{
    /// <summary>
    /// Class BinaryHeap<T> implements binary heap. 
    /// Min heap is implemented - smallest item has highest priority.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryHeap<T> : IEnumerable<T> where T : IComparable<T>
    {
        private List<T> data;
        public int Count { get; private set; }

        public BinaryHeap(int initalSize = 16)
        {
            data = new List<T>(initalSize);
            this.Count = 0;
        }

        public void Add(T item)
        {
            if (this.Count >= data.Capacity)
            {
                DoubleArraySize();
            }

            this.Count++;
            data.Add(item);            
            MoveUp(this.Count - 1);
        }

        public T GetPeak()
        {
            if (this.Count > 0)
            {
                T item = data.First();
                this.SwapElements(0, this.Count - 1);
                this.data.RemoveAt(this.Count - 1);
                this.Count--;
                this.MoveDown(0);

                return item;
            }

            throw new ArgumentNullException("No items to return!");
        }

        private void MoveUp(int idxCurrent)
        {
            int idxParrent = GetParentIndex(idxCurrent);
            while ((idxCurrent > 0) && (data[idxParrent].CompareTo(data[idxCurrent]) > 0))
            {
                this.SwapElements(idxCurrent, idxParrent);
                idxCurrent = idxParrent;
                idxParrent = GetParentIndex(idxCurrent);
            }
        }

        private void MoveDown(int idxCurrent)
        {
            int idxSmallest = idxCurrent;
            int idxLeftChild = GetLeftChildIndex(idxCurrent);
            int idxRightChild = GetRightChildIndex(idxCurrent);

            if ((idxLeftChild < this.Count) && (data[idxLeftChild].CompareTo(data[idxSmallest])) < 0)            
            {
                idxSmallest = idxLeftChild;
            }

            if ((idxRightChild < this.Count) && (data[idxRightChild].CompareTo(data[idxSmallest]) < 0))
            {
                idxSmallest = idxRightChild;
            }

            if (idxSmallest != idxCurrent)
            {
                this.SwapElements(idxSmallest, idxCurrent);
                MoveDown(idxSmallest);
            }
        }

        private void SwapElements(int pos1, int pos2)
        {
            T temp = data[pos1];
            data[pos1] = data[pos2];
            data[pos2] = temp;
        }

        private void DoubleArraySize()
        {
            List<T> copy = new List<T>(2 * this.data.Capacity);
            copy.AddRange(this.data);
            this.data = copy;
        }

        private int GetLeftChildIndex(int parentIndx)
        {
            var idx = 2 * parentIndx + 1;
            return idx;
        }

        private int GetRightChildIndex(int parentIndx)
        {
            int idx = 2 * parentIndx + 2;
            return idx;
        }

        private int GetParentIndex(int currentIdx)
        {
            var idx = Math.Floor((decimal)(currentIdx - 1) / 2);

            return Decimal.ToInt32(idx);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
