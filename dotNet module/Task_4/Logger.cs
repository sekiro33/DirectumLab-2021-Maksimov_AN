using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
  /// <summary>
  /// Логгер - класс для ведения логов.
  /// </summary>
  public class Logger : IDisposable
  {
    /// <summary>
    /// Файл логов.
    /// </summary>
    private FileStream logFile;

    /// <summary>
    /// Писатель в лог.
    /// </summary>
    private StreamWriter logWriter;

    /// <summary>
    /// Создать объект.
    /// </summary>
    /// <param name="fileName">Имя файла логов.</param>
    public Logger(string fileName)
    {
      this.logFile = new FileStream(fileName, FileMode.Append);
      this.logWriter = new StreamWriter(this.logFile);
    }

    /// <summary>
    /// Освободить ресурсы.
    /// </summary>
    public void Dispose()
    {
      this.logWriter.Dispose();
      this.logFile.Dispose();
    }

    /// <summary>
    /// Запись сообщения в файл.
    /// </summary>
    /// <param name="data">Сообщение.</param>
    public void WriteString(string data)
    {
      this.logWriter.WriteLine(data);
    }
  }
}
