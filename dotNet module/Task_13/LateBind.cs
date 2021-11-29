using System;
using System.Runtime.InteropServices;

namespace Task_13
{
  /// <summary>
  /// Позднее связывание.
  /// </summary>
  public class LateBind
  {
    /// <summary>
    /// Создание документа Excel и заполнение таблицей умножения.
    /// </summary>
    public static void CreateMultiplyTable()
    {
      var appId = "Excel.Application";
      var excelType = Type.GetTypeFromProgID(appId);
      dynamic excelApp = Activator.CreateInstance(excelType);

      excelApp.Visible = true;
      excelApp.DisplayAlerts = false;

      var workBook = excelApp.Workbooks.Add(Type.Missing);
      var sheet = workBook.Sheets[1];

      sheet.Name = "Таблица умножения";

      for (int i = 1; i <= 10; i++)
      {
        for (int j = 1; j <= 10; j++)
          sheet.Cells[i, j] = i * j;
      }

      excelApp.Application.ActiveWorkbook.SaveAs("LateBind.xlsx");
      Marshal.ReleaseComObject(excelApp);
      GC.GetTotalMemory(true);
    }
  }
}
