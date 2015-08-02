using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new HashTable<string, int>();
            dict.Add("Pesho", 28);
            dict["Pesho"] = 35;
            dict["Gosho"] = 34;
            dict["Bobi"] = 25;
            Console.WriteLine(dict.Find("Gosho").ToString());
        }
    }
}
