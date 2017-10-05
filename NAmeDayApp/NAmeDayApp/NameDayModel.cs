using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAmeDayApp
{

   public class NameDayModel
    {
        

        public int Day { get; set; }
        public int Month { get; set; }
        public IEnumerable<string> Name { get; set; }

        public NameDayModel(int Day, int Month, IEnumerable<string> Name)
        {
            this.Day = Day;
            this.Month = Month;
            this.Name = Name;
        }

        public string NameAsString => string.Join(", ", Name);
        public NameDayModel() { }
    }

}
