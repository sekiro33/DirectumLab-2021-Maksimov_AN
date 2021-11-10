using System;
using System.Data;
using System.Text;

namespace Task_4
{
  /// <summary>
  /// Program.
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    /// <param name="args">Аргументы.</param>
    static void Main(string[] args)
    {
      Console.WriteLine(ParseDataSet(GetStandartDataSet(), "\n", "\t"));
      Console.ReadKey();
    }

    /// <summary>
    /// Выполнить проход по набору данных и вернуть все его данные в виде одной строки.
    /// </summary>
    /// <param name="dataSet">Набор данных.</param>
    /// <param name="rowDelimeter">Разделитель записей.</param>
    /// <param name="columnDelimeter">Разделитель колонок.</param>
    /// <returns>Набор данных в виде одной строки.</returns>
    public static string ParseDataSet(DataSet dataSet, String rowDelimeter, String columnDelimeter)
    {
      StringBuilder parseResult = new StringBuilder();
      foreach (DataTable dt in dataSet.Tables)
      {
        foreach (DataRow row in dt.Rows)
        {
          var cells = row.ItemArray;
          foreach (var cell in cells)
            parseResult.Append(cell.ToString() + columnDelimeter);
          parseResult.Append(rowDelimeter);
        }
      }
      return parseResult.ToString();
    }

    /// <summary>
    /// Получить тестовый набор для метода.
    /// </summary>
    /// <returns>Тестовый набор.</returns>
    public static DataSet GetStandartDataSet()
    {
      DataSet bookStore = new DataSet("BookStore");
      DataTable booksTable = new DataTable("Books");
      bookStore.Tables.Add(booksTable);

      DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
      idColumn.Unique = true;
      idColumn.AllowDBNull = false;
      idColumn.AutoIncrement = true;
      idColumn.AutoIncrementSeed = 1;
      idColumn.AutoIncrementStep = 1;

      DataColumn nameColumn = new DataColumn("Name", Type.GetType("System.String"));
      DataColumn priceColumn = new DataColumn("Price", Type.GetType("System.Decimal"));
      priceColumn.DefaultValue = 100;
      DataColumn discountColumn = new DataColumn("Discount", Type.GetType("System.Decimal"));
      discountColumn.Expression = "Price * 0.2";

      booksTable.Columns.Add(idColumn);
      booksTable.Columns.Add(nameColumn);
      booksTable.Columns.Add(priceColumn);
      booksTable.Columns.Add(discountColumn);
      booksTable.PrimaryKey = new DataColumn[] { booksTable.Columns["Id"] };

      DataRow row = booksTable.NewRow();
      row.ItemArray = new object[] { null, "Война и мир", 200 };
      booksTable.Rows.Add(row); // добавляем первую строку
      booksTable.Rows.Add(new object[] { null, "Отцы и дети", 170 });

      return bookStore;
    }
  }
}
