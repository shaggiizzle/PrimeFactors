using System.Collections.Generic;

namespace PrimeFactors
{
  public interface IPrimeFactors
  {
    IEnumerable<int> GetPrimeFactors(int value);
  }
}