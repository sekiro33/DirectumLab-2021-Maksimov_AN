using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_12
{
  public class Person
  {
    private string name;
    private int age;

    [Obsolete]
    public string Name 
    { 
      get => this.name; 
      set => this.name = value; 
    }

    [Display(Name = "How much cost book")]
    public int Age
    {
      get => this.age; 
      
      set
      {
        if (this.age >= 0)
          this.age = value;
      }
    }
  }
}
