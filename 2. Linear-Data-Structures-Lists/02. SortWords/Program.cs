using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var line = Console.ReadLine();

        var words = line.Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList().OrderBy(w => w);
        Console.WriteLine( String.Join(" ", words));
    }
}

