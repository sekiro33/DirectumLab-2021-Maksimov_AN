using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
  class MeetingWithRemind : Meeting, IRemind
  {
    DateTime remindDateTime;
    public DateTime getDateTimeRemind()
    {
      return remindDateTime;
    }

    public void setDateTimeRemind(DateTime dateTimeRemind)
    {
      if (!(DateTime.Compare(dateTimeRemind, this.EndDate) > 0))
        remindDateTime = dateTimeRemind;
    }
  }
}
