using System.Threading;
using System.Globalization;
using System.Windows;

namespace LocalizedApp
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    static App()
    {
      Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
    }
  }
}
