using System.Collections;
using System.Collections.Generic;

namespace Task_8
{
  /// <summary>
  /// Класс для перебора строк текстового файла. Реализует <see cref="IEnumerable"/>.
  /// </summary>
  public class StreamReaderEnumerable : IEnumerable<string>
  {
    private string filePath;

    public StreamReaderEnumerable(string filePath)
    {
      this.filePath = filePath;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public IEnumerator<string> GetEnumerator()
    {
      return new StreamReaderEnumerator(this.filePath);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }
  }
}
