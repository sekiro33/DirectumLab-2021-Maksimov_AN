using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.Tests
{
  class FileReaderTest
  {
    [Test]
    public void ReadFileTest()
    {
      var fileName = "ClientConnectionLog.log";

      var expectedLines = new List<string>();

      using (var streamReader = new StreamReader(fileName))
      {
        while (!streamReader.EndOfStream)
          expectedLines.Add(streamReader.ReadLine());
      }

      var actualLines = new List<string>();

      foreach (var line in new StreamReaderEnumerable(fileName))
        actualLines.Add(line);

      Assert.AreEqual(expectedLines, actualLines);
    }
  }
}
