using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayStack
{
    public class ArrayStack<T>
    {
        private T[] elements;
        public int Count { get; private set; }
        private const int InitialCapacity = 16;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot Pop() from empty stack");
            }

            T element = this.elements[this.Count - 1];
            this.Count--;

            return element;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[this.Count];
            Array.Copy(this.elements, newArray, this.Count);

            return newArray;
        }

        private void Grow()
        {
            T[] newElements = new T[this.elements.Length * 2];
            Array.Copy(this.elements, newElements, this.Count);
            this.elements = newElements;
        }
    }
}