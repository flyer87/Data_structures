using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01_FindWordsInFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsFrequency = new Dictionary<string, int>();

            int cntLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < cntLines; i++)
            {
                string line = Console.ReadLine();
                string[] words = line.Split(new String[] { " ", ",", ".", "?", "!", ":", ";" }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < words.Length; j++)
                {
                    if (!wordsFrequency.ContainsKey(words[j]))
                    {
                        wordsFrequency.Add(words[j], 0);                    
                    }

                    wordsFrequency[words[j]]++;                  
                }
            }
            

            // Find
            cntLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < cntLines; i++)
            {
                string word = Console.ReadLine();
                int frequency = 0;
                wordsFrequency.TryGetValue(word, out frequency);
                Console.WriteLine(word + " -> " + frequency);
            }
        }
    }
}
