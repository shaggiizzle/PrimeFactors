using System;
using System.IO;

namespace PrimeFactors
{
  public class FileReader
  {

    private TextReader fileReader;
    private IPrimeFactors primeFactors;

    public FileReader(IPrimeFactors primeFactors, TextReader fileReader)
    {
      this.primeFactors = primeFactors;
      this.fileReader = fileReader;
    }

    public void ProcessFile()
    {

      string line;
      while ((line = fileReader.ReadLine()) != null)
      {
        if (int.TryParse(line, out int numberOnLine))
        {

          Console.WriteLine("For the number: {0}, thie prime factors are: {1}", numberOnLine,
            String.Join(",", primeFactors.GetPrimeFactors(numberOnLine)));

        }
        else
        {
          Console.WriteLine("Encountered Invalid Input");
        }
      }


    }

  }
}