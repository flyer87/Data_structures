using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02_BiDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var distances = new BiDictionary<string, string, int>();
            distances.Add("Sofia", "Varna", 443);
            distances.Add("Sofia", "Varna", 468);
            distances.Add("Sofia", "Varna", 490);
            distances.Add("Sofia", "Plovdiv", 145);
            distances.Add("Sofia", "Bourgas", 383);
            distances.Add("Plovdiv", "Bourgas", 253);
            distances.Add("Plovdiv", "Bourgas", 292);
            var distancesFromSofia = distances.FindByKey1("Sofia"); // [443, 468, 490, 145, 383]
            Print(distancesFromSofia);
            var distancesToBourgas = distances.FindByKey2("Bourgas"); // [383, 253, 292]
            Print(distancesToBourgas);
            var distancesPlovdivBourgas = distances.Find("Plovdiv", "Bourgas"); // [253, 292]
            Print(distancesPlovdivBourgas);
            var distancesRousseVarna = distances.Find("Rousse", "Varna"); // []
            Print(distancesRousseVarna);
            var distancesSofiaVarna = distances.Find("Sofia", "Varna"); // [443, 468, 490]
            Print(distancesSofiaVarna);            
            distances.Remove("Sofia", "Varna"); // true
            var distancesFromSofiaAgain = distances.FindByKey1("Sofia"); // [145, 383]
            Print(distancesFromSofiaAgain);
            var distancesToVarna = distances.FindByKey2("Varna"); // []
            Print(distancesToVarna);
            var distancesSofiaVarnaAgain = distances.Find("Sofia", "Varna"); // []
            Print(distancesSofiaVarnaAgain);
        }

        static void Print(IEnumerable<int> list)
        {
            string distancesStr = "";
            foreach (var item in list)
            {
                distancesStr = distancesStr + item + ", ";
            }

            Console.WriteLine(distancesStr);
        }
    }
}
