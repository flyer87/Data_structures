using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02_BiDictionary
{
    public class BiDictionary<K1, K2, T>
    {
        private Dictionary<K1, List<T>> valuesByFirstKey = new Dictionary<K1, List<T>>();
        private Dictionary<K2, List<T>> valuesBySecondKey = new Dictionary<K2, List<T>>();
        private Dictionary<Tuple<K1, K2>, List<T>> valuesByBothKeys = 
            new Dictionary<Tuple<K1, K2>, List<T>>();

        public void Add(K1 key1, K2 key2, T value)
        {
            valuesByFirstKey.AppendValueToKey(key1, value);
            valuesBySecondKey.AppendValueToKey(key2, value);
            valuesByBothKeys.AppendValueToKey(new Tuple<K1, K2>(key1, key2), value);
        }

        public IEnumerable<T> Find(K1 key1, K2 key2)
        {
            return this.valuesByBothKeys.GetValuesForKeys(key1, key2);            
        }
        public IEnumerable<T> FindByKey1(K1 key1)
        {
            return valuesByFirstKey.GetValuesForKey(key1);                  
        }
        public IEnumerable<T> FindByKey2(K2 key2)
        {
            return valuesBySecondKey.GetValuesForKey(key2);                  
        }
        public bool Remove(K1 key1, K2 key2)
        {
            var dictances = this.Find(key1, key2);
            if (dictances == null)
            {
                return false;
            }
            
            foreach (var distance in dictances)
            {
                valuesByFirstKey[key1].Remove(distance);
                valuesBySecondKey[key2].Remove(distance);
            }
            valuesByBothKeys[new Tuple<K1, K2>(key1, key2)].Clear();
            return true;
            
        }
    }
}
