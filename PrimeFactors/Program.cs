using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PrimeFactors
{
  class Program
  {
    static void Main(string[] args)
    {
      PrimeFactors primeFactors = new PrimeFactors();
      
      if (args.Any())
      {
        var path = args[0];
        if (File.Exists(path))
        {
          try
          {
            using (StreamReader fileReader = new StreamReader(path))
            {
              FileReader fileProcessor = new FileReader(primeFactors, fileReader);

              fileProcessor.ProcessFile();

            }
            Console.ReadLine();
          }
          catch (Exception e)
          {
            Console.Write("The file could not be read: ");
            Console.WriteLine(e.Message);
          }
        }
      }

    }
  }
}
