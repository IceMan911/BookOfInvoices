using System;
using System.IO;
using System.Linq;
using BookOfInvoices.Models;

namespace BookOfInvoices
{
    class Program
    {
        static TextReader input = Console.In;
        static void Main(string[] args)
        {
            int minPocetFaktur = 0;
            int maxPocetFaktur = 0;
            int nacteno = 0;

            if (args.Any())
            {
                var path = args[0];
                if (File.Exists(path))
                {
                    input = File.OpenText(path);
                }
            }

#if (DEBUG)
            Console.WriteLine("Mode=Debug");
            string line;

            Console.WriteLine("Zadej hodnotu pro minPocetFaktur ve formatu: 'minPocetFaktur =cislo'");
            line = input.ReadLine();
            if (line.Contains(Helpers.getMinValue()))
            {
                minPocetFaktur = Helpers.getIntFromString(line);
            }

            Console.WriteLine("Zadej hodnotu maxPocetFaktur ve formatu: 'maxPocetFaktur =cislo'");
            line = input.ReadLine();
            if (line.Contains(Helpers.getMaxValue()))
            {
                maxPocetFaktur = Helpers.getIntFromString(line);
            }
#elif (RELEASE)
            // use `input` for all input operations
            for (string line; (line = input.ReadLine()) != null;)
            {
                Console.WriteLine("Zadej hodnoty pro minPocetFaktur a maxPocetFaktur");
                if (line.Contains(Helpers.getMaxValue()))
                {
                    maxPocetFaktur = Helpers.getIntFromString(line);
                    nacteno++;
                }
                if (line.Contains(Helpers.getMinValue()))
                {
                    minPocetFaktur = Helpers.getIntFromString(line);
                    nacteno++;
                }

                if (nacteno == 2)
                {
                    break;
                }
            }
#endif

            BookOfInvoice bookOfInvoice = new BookOfInvoice();
            bookOfInvoice.fillBookOfInvoices(minPocetFaktur, maxPocetFaktur);
            bookOfInvoice.printResult();

            Console.WriteLine("END");
        }
    }
}
