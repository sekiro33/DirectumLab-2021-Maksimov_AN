namespace Task_13
{
  /// <summary>
  /// Program.
  /// </summary>
  class Program
  {
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    /// <param name="args">Параметры.</param>
    static void Main(string[] args)
    {
      //Создание таблицы умножение в Excel при помощи раннего связывания
      EarlyBind.CreateMultiplyTable();

      //Создание таблицы умножение в Excel при помощи позднего связывания
      LateBind.CreateMultiplyTable();
    }
  }
}
