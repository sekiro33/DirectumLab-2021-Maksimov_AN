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
    private static void Main(string[] args)
    {
      /*using (Logger logger = new Logger("log.txt"))
      {
        logger.WriteString("Hello, Directum!");
      }
      Console.Write(GetAllowsRights(AccessRights.Run | AccessRights.View));*/
      Console.WriteLine(ParseDataSet(GetStandartDataSet(), "\n", " "));
      Console.ReadKey();
    }

    /// <summary>
    /// Получить перечень действий, разрешенных правами.
    /// </summary>
    /// <param name="accessRights">Тип прав доступа.</param>
    /// <returns>Строка с перечнем действий.</returns>
    public static string GetAllowsRights(AccessRights accessRights)
    {
      if (accessRights.HasFlag(AccessRights.AccessDenied))
      {
        return AccessRights.AccessDenied.ToString();
      }
      else
      {
        var allowsRights = new StringBuilder();
        foreach (AccessRights r in Enum.GetValues(typeof(AccessRights)))
        {
          if (accessRights.HasFlag(r))
            allowsRights.AppendLine(r.ToString());
        }
        return allowsRights.ToString();
      }
    }

    /// <summary>
    /// Замер скорости конкатенации строк.
    /// </summary>
    private static void TestSpeedConcat()
    {
      /*
       * Исходя из результатов тестирования, можно сказать, что на 100'000 итераций
       * обычная конкатенация уже выполняется довольно долго. При увеличении ещё в 10 раз
       * приходится ждать очень долго.
       * Конкатенация средствами StringBuilder при этих же количествах итерации выполняется
       * гораздо быстрее.
       */
      Console.WriteLine("Замер скорости конкатенации строк:");
      for (int i = 1; i < 7; i++)
      {
        int countCycles = (int)Math.Pow(10, i);
        SpeedComprasionTest.СycleCount = countCycles;
        Console.WriteLine("Количество итераций: " + countCycles);
        Console.WriteLine("Средствами класса String: " + SpeedComprasionTest.TestConcatStringSpeed());
        Console.WriteLine("Средствами класса StringBuilder: " + SpeedComprasionTest.TestConcatStringBuilderSpeed());
        Console.WriteLine();
      }
    }

    /// <summary>
    /// Выполнить проход по набору данных и вернуть все его данные в виде одной строки.
    /// </summary>
    /// <param name="dataSet">Набор данных.</param>
    /// <param name="rowDelimeter">Разделитель записей.</param>
    /// <param name="columnDelimeter">Разделитель колонок.</param>
    /// <returns>Набор данных в виде одной строки.</returns>
    public static string ParseDataSet(DataSet dataSet, string rowDelimeter, string columnDelimeter)
    {
      var parseResult = new StringBuilder();
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
    private static DataSet GetStandartDataSet()
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
      booksTable.Rows.Add(row); // добавляем первую строку
      booksTable.Rows.Add(new object[] { null, "Отцы и дети", 170 });

      return bookStore;
    }
  }
}
