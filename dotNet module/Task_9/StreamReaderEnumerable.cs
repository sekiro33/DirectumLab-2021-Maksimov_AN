using System.Collections;
using System.Collections.Generic;

namespace Task_9
{
  public class StreamReaderEnumerable : IEnumerable<string>
  {
    private string filePath;

    public StreamReaderEnumerable(string filePath)
    {
      this.filePath = filePath;
    }

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