using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T01_Dictionary;

namespace T02_CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var symbols_occur = new HashTable<char, int>();
            string text = Console.ReadLine();
            
            for (int i = 0; i < text.Length; i++)
            {
                if (!symbols_occur.ContainsKey(text[i]))
                {
                    symbols_occur[text[i]] = 0;
                }

                symbols_occur[text[i]] += 1;
            }

            var ordered_symbols_occur = symbols_occur.OrderBy(element => element.Key);

            foreach (var symbol in ordered_symbols_occur)
            {
                Console.WriteLine("{0}: {1} time/s", symbol.Key, symbol.Value);
            }
        }
    }
}
