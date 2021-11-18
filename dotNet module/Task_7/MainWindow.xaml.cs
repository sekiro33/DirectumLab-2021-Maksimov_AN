using Microsoft.Win32;
using System.IO;
using System.IO.Compression;
using System.Windows;
using System.Windows.Documents;

namespace Task_7
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml.
  /// </summary>
  public partial class MainWindow : Window
  {
    /// <summary>
    /// Создать окно для MainWindow.xaml.
    /// </summary>
    public MainWindow()
    {
      this.InitializeComponent();
    }

    /// <summary>
    /// Обработчик нажатия на кнопку "Обзор".
    /// </summary>
    /// <param name="sender">Объект, который вызвал событие.</param>
    /// <param name="e">Объект, относящийся к обрабатываемому событию.</param>
    private void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
      var openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Текстовый файл, сжатый по методу GZIP|*.gz";

      if (openFileDialog.ShowDialog() == true)
      {
        AbsolutePathTextField.Text = openFileDialog.FileName;
        this.ReadFile(AbsolutePathTextField.Text);
      }
    }

    /// <summary>
    /// Прочитать файл по пути path и добавить текст в RichTextBox.
    /// </summary>
    /// <param name="path">Путь к файлу.</param>
    private void ReadFile(string path)
    {
      TextRange range = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
      using (var inputFile = File.OpenRead(path))
      using (var zipStream = new GZipStream(inputFile, CompressionMode.Decompress))
        range.Load(zipStream, DataFormats.Rtf);
    }
  }
}
