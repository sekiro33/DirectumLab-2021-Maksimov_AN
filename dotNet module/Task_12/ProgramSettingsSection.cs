using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_12
{
  /// <summary>
  /// Секция ProgramSettingsSection.
  /// </summary>
  public class ProgramSettingsSection : ConfigurationSection
  {
    /// <summary>
    /// Получить коллекцию состоящую из ProgramSettingsElement.
    /// </summary>
    [ConfigurationProperty("", IsDefaultCollection = true, IsRequired = false)]
    public ProgramSettingsCollection ProgramSettings => (ProgramSettingsCollection)this[string.Empty];

    /// <summary>
    /// StrSetting.
    /// </summary>
    [ConfigurationProperty("StrSetting", IsRequired = true)]
    public string StrSetting 
    { 
      get
      {
        return (string)this["StrSetting"];
      }

      set
      {
        this["StrSetting"] = value;
      }
    }

    /// <summary>
    /// IntSetting.
    /// </summary>
    [ConfigurationProperty("IntSetting", IsRequired = true, IsKey = true)]
    public int IntSetting
    {
      get
      {
        return (int)this["IntSetting"];
      }

      set
      {
        this["IntSetting"] = value;
      }
    }
  }
}
