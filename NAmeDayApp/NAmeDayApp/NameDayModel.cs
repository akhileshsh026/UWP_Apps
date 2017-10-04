using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAmeDayApp
{
    class NameDayModel
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public IEnumerable<string> Name { get; set; }

        public string NameAsString => string.Join(", ", Name);
            
    }

}
