using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAmeDayApp
{
    class NameDayModel
    {
        public int Day { get;  }
        public int Month { get;  }
        public IEnumerable<string> Name { get; }

        public NameDayModel(int Day, int Month, IEnumerable<string> Name)
        {
            this.Day = Day;
            this.Month = Month;
            this.Name = Name;
        }

        public string NameAsString => string.Join(", ", Name);
            
    }

}
