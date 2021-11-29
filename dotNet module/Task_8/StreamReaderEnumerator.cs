using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Task_8
{
  /// <summary>
  /// Реализация <see cref="IEnumerator"/>.
  /// </summary>
  public class StreamReaderEnumerator : IEnumerator<string>
  {
    private StreamReader streamReader;

    public StreamReaderEnumerator(string filePath)
    {
      this.streamReader = new StreamReader(filePath);
    }

    private string current;

    /// <summary>
    /// Текущая строка.
    /// </summary>
    public string Current
    {
      get
      {
        if (this.streamReader == null || this.current == null)
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

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public bool MoveNext()
    {
      this.current = this.streamReader.ReadLine();
      if (this.current == null)
        return false;
      return true;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Reset()
    {
      this.streamReader.DiscardBufferedData();
      this.streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
      this.current = null;
    }

    private bool disposedValue = false;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Dispose()
    {
      this.Dispose(disposing: true);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposedValue)
      {
        this.current = null;
        if (this.streamReader != null)
        {
          this.streamReader.Close();
          this.streamReader.Dispose();
        }
      }

      this.disposedValue = true;
    }

    ~StreamReaderEnumerator()
    {
      this.Dispose(disposing: false);
    }
  }
}
