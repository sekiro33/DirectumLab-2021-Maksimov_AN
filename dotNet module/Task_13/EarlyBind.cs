using System;

using Microsoft.Office.Interop.Excel;

namespace Task_13
{
  /// <summary>
  /// Раннее связывание.
  /// </summary>
  public class EarlyBind
  {
    /// <summary>
    /// Создание документа Excel и заполнение таблицей умножения.
    /// </summary>
    public static void CreateMultiplyTable()
    {
      var excelApp = new Application();
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

      excelApp.Application.ActiveWorkbook.SaveAs("EarlyBind.xlsx");
    }
  }
}
