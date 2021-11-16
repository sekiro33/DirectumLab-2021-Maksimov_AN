using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace Task_7
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    /// <summary>
    /// 
    /// </summary>
    public MainWindow()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Обработчик нажатия на кнопку "Обзор".
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
      var openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Текстовый файл, сжатый по методу GZIP|*.gz";

      if (openFileDialog.ShowDialog() == true)
      {
        AbsolutePathTextField.Text = openFileDialog.FileName;
      }
    }

    private void ReadFile(string path)
    {
    
    }
  }
}
