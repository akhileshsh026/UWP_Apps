using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAmeDayApp
{
    class MainPageData : INotifyPropertyChanged
    {
        public string _greeting = "Hello Hello";

        public string Greeting
        {
            get
            {
                return _greeting;
            }
            set
            {
                if (value == _greeting)
                    return;

                _greeting = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Greeting)));
            }
        }

        public List<NameDayModel> NameDays { get; set; }

        public MainPageData()
        {
            NameDays = new List<NameDayModel>();

            for (int month = 1; month <= 12; month++)
            {
                NameDays.Add(new NameDayModel(19, month, new string[] { "Akhilesh KS" }));
                NameDays.Add(new NameDayModel(14, month, new string[] { "Bittu", "Allwin", "Cow" }));
                NameDays.Add(new NameDayModel(16, month, new string[] { "Akash", "Saurabh", "Kallu" }));
            }
        }

        private NameDayModel _selectedNameDay;

        public event PropertyChangedEventHandler PropertyChanged;

        public NameDayModel SelectedNameDay
        {
            get { return _selectedNameDay; }
            set
            {
                _selectedNameDay = value;

                if (value == null)
                    Greeting = "Hello Hello please select value !";
                else
                    Greeting = "Hello " + value.NameAsString;
            }
        }


    }
}
