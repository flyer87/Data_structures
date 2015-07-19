using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class ReversedList<T> : IEnumerable<T>
{
    private T[] innerList;  
    public long Count { get; private set; }

    public long Capacity { get; private set; }    

    public void Add(T item)
    {
        if (this.Count == innerList.Count())
        {
            DoubleCapacity();
        }

        this.Count++;
        innerList[this.Count] = item;
    }

    private void DoubleCapacity()
    {
        this.Capacity *= 2;
        T[] newarr = new T[this.Capacity];
        Array.Copy(this.innerList, newarr, this.innerList.Count());
        this.innerList = newarr;
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}