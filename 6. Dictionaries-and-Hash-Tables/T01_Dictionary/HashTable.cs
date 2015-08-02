using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T01_Dictionary
{
    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private LinkedList<KeyValue<TKey, TValue>>[] slots;
        private const int INITIAL_CAPACITY = 16;
        private const float LOAD_FACTOR = 0.75f;

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return slots.Length;
            }
        }

        public HashTable(int capacity = INITIAL_CAPACITY)
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
            this.Count = 0;
        }

        public void Add(TKey key, TValue value)
        {
            GrowIfNeeded();
            int slotNumberToSet = this.FindSlotNumber(key);
            if (slots[slotNumberToSet] == null)
            {
                slots[slotNumberToSet] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (var element in this.slots[slotNumberToSet])
            {
                if (element.Key.Equals(key))
                {
                    throw new ArgumentException("Key already exists: " + key + " !");
                }
            }

            slots[slotNumberToSet].AddLast(new KeyValue<TKey, TValue>(key, value));
            this.Count++;
        }

        private void GrowIfNeeded()
        {
            if (((float)(this.Count + 1) / this.slots.Length) > LOAD_FACTOR)
            {
                this.Grow();
            }
        }

        private void Grow()
        {
            var newHashTable = new HashTable<TKey, TValue>(2 * this.slots.Length);
            foreach (var element in this)
            {
                newHashTable.Add(element.Key, element.Value);
            }
            this.slots = newHashTable.slots;
            this.Count = newHashTable.Count;
        }

        private int FindSlotNumber(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % this.slots.Length;
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            GrowIfNeeded();
            int slotNumberToSet = this.FindSlotNumber(key);
            if (slots[slotNumberToSet] == null)
            {
                slots[slotNumberToSet] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (var element in this.slots[slotNumberToSet])
            {
                if (element.Key.Equals(key))
                {
                    element.Value = value;
                    return false;
                }
            }

            var newElement = new KeyValue<TKey, TValue>(key, value);
            slots[slotNumberToSet].AddLast(newElement);
            this.Count++;
            return true;
        }

        public TValue Get(TKey key)
        {
            var item = this.Find(key);
            if (item != null)
            {
                return item.Value;
            }
            else
            {
                // Note: throw an exception on missing key
                throw new KeyNotFoundException("Key not found: " + key);
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.Get(key);
            }
            set
            {
                this.AddOrReplace(key, value);
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var item = this.Find(key);
            if (item != null)
            {
                value = item.Value;
                return true;
            }
            else
            {
                value = default(TValue);
                return false;
            }
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int slotNumber = FindSlotNumber(key);
            var elements = slots[slotNumber];
            if (elements != null)
            {
                foreach (var element in elements)
                {
                    if (element.Key.Equals(key))
                    {
                        return element;
                    }
                }
            }

            return null;
        }

        public bool ContainsKey(TKey key)
        {
            //throw new NotImplementedException();
            var element = this.Find(key);
            if (element != null)
            {
                return true;
            }

            return false;
        }

        public bool Remove(TKey key)
        {
            int slotNumber = this.FindSlotNumber(key);
            var elements = this.slots[slotNumber];
            if (elements != null)
            {
                var currentElement = elements.First;
                while (currentElement != null)
                {
                    if (currentElement.Value.Key.Equals(key))
                    {
                        elements.Remove(currentElement);
                        this.Count--;
                        return true;
                    }
                    currentElement = currentElement.Next;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.Count = 0;
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[this.slots.Length];
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                return this.Select(element => element.Key);
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                return this.Select(element => element.Value);
            }
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var items in this.slots)
            {
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        yield return item;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}