using System.Configuration;

namespace Task_12
{
  /// <summary>
  /// Элемент ProgramSettingsElement.
  /// </summary>
  public class ProgramSettingsElement : ConfigurationElement
  {
    /// <summary>
    /// SubSetting.
    /// </summary>
    [ConfigurationProperty(nameof(SubSetting), IsRequired = true, IsKey = true)]
    public string SubSetting => (string)this[nameof(this.SubSetting)];

    /// <summary>
    /// SubSettingValue.
    /// </summary>
    [ConfigurationProperty(nameof(SubSettingValue), IsRequired = true)]
    public string SubSettingValue => (string)this[nameof(this.SubSettingValue)];
  }
}
