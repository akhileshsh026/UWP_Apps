using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAmeDayApp
{
    class MainPageData
    {
        public string _greeting { get; set; } = "Hello World";

        public List<NameDayModel> NameDays { get; set; }

        public MainPageData()
        {
            NameDays = new List<NameDayModel>();

            for (int month = 1; month <= 12; month++)
            {
                NameDays.Add(new NameDayModel( 19, month, new string[] { "Akhilesh KS" }));
                NameDays.Add(new NameDayModel(14, month, new string[] { "Bittu","Allwin","Cow" }));
                NameDays.Add(new NameDayModel(16, month, new string[] { "Akash", "Saurabh", "Kallu" }));
            }
        }

    }
}
