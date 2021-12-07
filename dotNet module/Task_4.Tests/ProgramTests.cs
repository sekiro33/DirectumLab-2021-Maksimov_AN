using NUnit.Framework;
using System;
using System.Data;
using System.IO;
using System.Text;

namespace Task_4.Tests
{
  public class ProgramTests
  {
    [Test]
    public void ParseDataSetTest()
    {
      var rowDelimeter = "\n";
      var columnDelimeter = " ";

      var inputDataSet = CreateTestDataSet();

      var actualParseResult = Program.ParseDataSet(inputDataSet, rowDelimeter, columnDelimeter);

      var expectedParseResult = "1 Война и мир 200 40,0 \n2 Отцы и дети 170 34,0 \n";

      Assert.AreEqual(expectedParseResult, actualParseResult);
    }

    private DataSet CreateTestDataSet()
    {
      var bookStore = new DataSet("BookStore");
      var booksTable = new DataTable("Books");
      bookStore.Tables.Add(booksTable);

      var idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
      idColumn.Unique = true;
      idColumn.AllowDBNull = false;
      idColumn.AutoIncrement = true;
      idColumn.AutoIncrementSeed = 1;
      idColumn.AutoIncrementStep = 1;

      var nameColumn = new DataColumn("Name", Type.GetType("System.String"));
      var priceColumn = new DataColumn("Price", Type.GetType("System.Decimal"));
      priceColumn.DefaultValue = 100;
      var discountColumn = new DataColumn("Discount", Type.GetType("System.Decimal"));
      discountColumn.Expression = "Price * 0.2";

      booksTable.Columns.Add(idColumn);
      booksTable.Columns.Add(nameColumn);
      booksTable.Columns.Add(priceColumn);
      booksTable.Columns.Add(discountColumn);
      booksTable.PrimaryKey = new DataColumn[] { booksTable.Columns["Id"] };

      var row = booksTable.NewRow();
      row.ItemArray = new object[] { null, "Война и мир", 200 };
      booksTable.Rows.Add(row);
      booksTable.Rows.Add(new object[] { null, "Отцы и дети", 170 });

      return bookStore;
    }

    [Test]
    public void AllowsRightTest_AccessDenied()
    {
      var inputRights = AccessRights.AccessDenied;

      var actual = Program.GetAllowsRights(inputRights);

      var expected = AccessRights.AccessDenied.ToString();

      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void AllowsRightTest_ViewAndRun()
    {
      var inputRights = AccessRights.View | AccessRights.Run;

      var actual = Program.GetAllowsRights(inputRights);

      var expected = new StringBuilder();
      expected.AppendLine(AccessRights.View.ToString());
      expected.AppendLine(AccessRights.Run.ToString());

      Assert.AreEqual(expected.ToString(), actual);
    }

    [Test]
    public void LoggerTest()
    {
      using (var logger = new Logger("log.txt"))
      {
        logger.WriteString("testLog");
      }

      var expected = "testLog";
      string actual = string.Empty;

      using (var streamReader = new StreamReader("log.txt"))
      {
        actual = streamReader.ReadLine();
      }

      Assert.AreEqual(expected, actual);
    }
  }
}