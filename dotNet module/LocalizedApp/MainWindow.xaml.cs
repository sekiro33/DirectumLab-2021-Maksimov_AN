using System;
using System.Reflection;
using System.Resources;
using System.Windows;

namespace LocalizedApp
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void HelloButton_Click(object sender, RoutedEventArgs e)
    {
      MessageBox.Show(TextMessages.HelloMessage);
    }

    private void Window_Initialized(object sender, EventArgs e)
    {
      var resMan = new ResourceManager("LocalizedApp.TextMessages", Assembly.GetExecutingAssembly());
      MessageBox.Show(resMan.GetString("HelloMessage", new System.Globalization.CultureInfo("en")));
    }
  }
}
