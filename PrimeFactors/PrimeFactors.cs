using System;
using System.Collections.Generic;


namespace PrimeFactors
{
  public class PrimeFactors : IPrimeFactors
  {
    private int value;

    public IEnumerable<int> GetPrimeFactors(int input)
    {
      value = Math.Abs(input);
      if (value == 1 || value == 0)
      {
        yield break;
      }

      for (int factor=2; factor <= value; factor++)
      {
         if (value % factor == 0 && IsPrime(factor))
        {
          while (value % factor == 0)
          {
            value /= factor;
            yield return factor;
          }
        }
      }

    }

    private bool IsPrime(int value)
    {
      if (value == 2) return true;
      for (int i=2; i <= value /2; i++)
      {
        if (value % i == 0) return false;
      }
      return true;
    }
  }
}
