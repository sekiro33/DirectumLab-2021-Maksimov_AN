using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Task_9
{
  /// <summary>
  /// StreamReaderEnumerator.
  /// </summary>
  public class StreamReaderEnumerator : IEnumerator<string>
  {
    private StreamReader sr;

    /// <summary>
    /// Создать перечислитель, выполняющий перебор строк в файле.
    /// </summary>
    /// <param name="filePath">Путь к файлу.</param>
    public StreamReaderEnumerator(string filePath)
    {
      this.sr = new StreamReader(filePath);
    }

    private string current;

    /// <summary>
    /// Текущая строка.
    /// </summary>
    public string Current
    {
      get
      {
        if (this.sr == null || this.current == null)
        {
          throw new InvalidOperationException();
        }

        return this.current;
      }
    }

    object IEnumerator.Current
    {
      get { return this.Current; }
    }

    /// <inheritdoc/>
    public bool MoveNext()
    {
      this.current = this.sr.ReadLine();
      if (this.current == null)
        return false;
      return true;
    }

    /// <inheritdoc/>
    public void Reset()
    {
      this.sr.DiscardBufferedData();
      this.sr.BaseStream.Seek(0, SeekOrigin.Begin);
      this.current = null;
    }

    private bool disposedValue = false;

    /// <inheritdoc/>
    public void Dispose()
    {
      if (!this.disposedValue)
      {
        this.current = null;
        if (this.sr != null)
        {
          this.sr.Close();
          this.sr.Dispose();
        }
      }

      this.disposedValue = true;
      GC.SuppressFinalize(this);
    }

    ~StreamReaderEnumerator()
    {
      this.Dispose();
    }
  }
}
