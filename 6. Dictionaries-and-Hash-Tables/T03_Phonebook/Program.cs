using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T01_Dictionary;

namespace T03_Phonebook
{
    class Program
    {
        const string DELIMITER = "-";
        static void ReadInput()
        {
        }

        static void Main(string[] args)
        {
            HashTable<string, string> phoneBook = new HashTable<string, string>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "search")
                {
                    while (true)
                    {
                        line = Console.ReadLine();
                        if (line == "break")
                        {
                            break;
                        }

                        var entry = phoneBook.Find(line);
                        if (entry != null)
                        {
                            Console.WriteLine("{0} -> {1}", entry.Key, entry.Value);
                        }
                        else
                        {
                            Console.WriteLine("Contact {0} does not exist!", line);
                        }
                    }
                }
                else
                {
                    string[] phoneEntries = line.Split(new string[] { DELIMITER }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    phoneBook.Add(phoneEntries[0], phoneEntries[1]);
                }
            }
        }
    }
}