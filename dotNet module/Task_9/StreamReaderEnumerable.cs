using System.Collections;
using System.Collections.Generic;

namespace Task_9
{
  /// <summary>
  /// StreamReaderEnumerable.
  /// </summary>
  public class StreamReaderEnumerable : IEnumerable<string>
  {
    private string filePath;

    /// <summary>
    /// StreamReaderEnumerable.
    /// </summary>
    /// <param name="filePath">Путь к файлу.</param>
    public StreamReaderEnumerable(string filePath)
    {
      this.filePath = filePath;
    }

    /// <inheritdoc/>
    public IEnumerator<string> GetEnumerator()
    {
      return new StreamReaderEnumerator(this.filePath);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }
  }
}