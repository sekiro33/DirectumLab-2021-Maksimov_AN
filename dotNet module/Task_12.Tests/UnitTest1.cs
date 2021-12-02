using NUnit.Framework;
using System.Collections.Generic;

namespace Task_12.Tests
{
  public class ReaddPropertiesTest
  {
    [Test]
    public void TestReadAllReadWriteProperties()
    {
      var person = new Person();
      var actual = Program.GetAllReadWriteProperties(person);
      var expected = new Dictionary<string, string>();
      expected.Add("Name", "String");
      expected.Add("Age", "Int32");
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TestReadAllReadWritePropertiesIgnoreObsolete()
    {
      var person = new Person();
      var actual = Program.GetAllReadWritePropertiesWithIgnoreObsolete(person);
      var expected = new Dictionary<string, string>();
      expected.Add("Age", "Int32");
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TestReadAllReadWritePropertiesByClassName()
    {
      var actual = Program.GetAllReadWriteProperties(typeof(Program).Assembly.Location, typeof(Person).FullName);
      var expected = new Dictionary<string, string>();
      expected.Add("Name", "String");
      expected.Add("Age", "Int32");
      Assert.AreEqual(expected, actual);
    }
  }
}