using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeFactors;
using Moq;
using System.IO;

namespace PrimeFactorsTest
{
  [TestClass]
  public class FileReaderTest
  {
    StreamReader fileReader;
    StreamWriter fileWriter;
    StringWriter standardOut;
    FileReader fileReaderProgram;
    MemoryStream input;
    [TestInitialize]
    public void Setup()
    {
      input = new MemoryStream();
      fileReader = new StreamReader(input);
      fileWriter = new StreamWriter(input);
      Mock<IPrimeFactors> mockPrimeFactors = new Mock<IPrimeFactors>();
      mockPrimeFactors.Setup(x => x.GetPrimeFactors(It.IsAny<int>())).Returns(new[] { 2 });
      fileReaderProgram = new FileReader(mockPrimeFactors.Object, fileReader);

      standardOut = new StringWriter();
      Console.SetOut(standardOut);
    }

    [TestCleanup]
    public void CleanUp()
    {

      try
      {
        fileReader.Close();
        fileReader.Dispose();
      }
      catch (Exception e)
      {
        Console.Error.WriteLine(e);
        throw (e);
      }

      try
      {
        fileWriter.Close();
        fileWriter.Dispose();
      }
      catch (Exception e)
      {
        Console.Error.WriteLine(e);
        throw (e);
      }

      try
      {
        input.Close();
        input.Dispose();
      }
      catch (Exception e)
      {
        Console.Error.WriteLine(e);
        throw (e);
      }

      StreamWriter sw = new StreamWriter(Console.OpenStandardOutput())
      {
        AutoFlush = true
      };
      Console.SetOut(sw);
    }

    [TestMethod]
    public void TestValidSingleLineFile()
    {
      fileWriter.Write("2");
      fileWriter.Flush();
      input.Position = 0;
      fileReaderProgram.ProcessFile();
      Assert.AreEqual("For the number: 2, thie prime factors are: 2" + standardOut.NewLine, standardOut.ToString());
    }

    [TestMethod]
    public void TestInvalidSingleLineFile()
    {
      fileWriter.Write("Not a number");
      fileWriter.Flush();
      input.Position = 0;
      fileReaderProgram.ProcessFile();
      Assert.AreEqual("Encountered Invalid Input" + standardOut.NewLine, standardOut.ToString());
    }

    [TestMethod]
    public void TestEmptyFile()
    {
      fileWriter.Flush();
      input.Position = 0;
      fileReaderProgram.ProcessFile();
      Assert.AreEqual("", standardOut.ToString());
    }
  }
}
