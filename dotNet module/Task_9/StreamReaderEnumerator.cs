﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Task_9
{
  public class StreamReaderEnumerator : IEnumerator<string>
  {
    private StreamReader sr;

    public StreamReaderEnumerator(string filePath)
    {
      this.sr = new StreamReader(filePath);
    }

    private string current;

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

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public bool MoveNext()
    {
      this.current = this.sr.ReadLine();
      if (this.current == null)
        return false;
      return true;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Reset()
    {
      this.sr.DiscardBufferedData();
      this.sr.BaseStream.Seek(0, SeekOrigin.Begin);
      this.current = null;
    }

    private bool disposedValue = false;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Dispose()
    {
      this.Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Освобождение ресурсов.
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
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
    }

    ~StreamReaderEnumerator()
    {
      this.Dispose(disposing: false);
    }
  }
}
