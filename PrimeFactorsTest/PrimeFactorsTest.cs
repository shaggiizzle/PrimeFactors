using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeFactors;

namespace PrimeFactorsTest
{
  [TestClass]
  public class PrimeFactorsTest
  {
    PrimeFactors.PrimeFactors prime = new PrimeFactors.PrimeFactors();
    
    [TestMethod]
    public void TestWith0()
    {
      List<int> result = new List<int>(prime.GetPrimeFactors(0));
      Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public void TestWith1()
    {
      List<int> result = new List<int>(prime.GetPrimeFactors(1));
      Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public void TestWith52()
    {
      List<int> result = new List<int>(prime.GetPrimeFactors(52));
      Assert.AreEqual(3, result.Count);
      Assert.AreEqual(2, result[0]);
      Assert.AreEqual(2, result[0]);
      Assert.AreEqual(13, result[2]);
      Assert.AreEqual(52, result.Aggregate(1, (total, next) => next * total));
    }
  }
}
