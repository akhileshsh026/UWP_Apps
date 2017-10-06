using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<NameDayModel> NameDays { get; set; }

        public MainPageData()
        {
            NameDays = new ObservableCollection<NameDayModel>();

            //if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)   // diffreenciate between the runtime and design time data.
            //{
              
            //}
            //else


                for (int month = 1; month <= 12; month++)
                {
                    _allNameDays.Add(new NameDayModel(19, month, new string[] { "Akhilesh KS" }));
                    _allNameDays.Add(new NameDayModel(14, month, new string[] { "Bittu", "Allwin", "Cow" }));
                    _allNameDays.Add(new NameDayModel(16, month, new string[] { "Akash", "Saurabh", "Kallu" }));
                }
            PerformFiltering();
            // LoadData();
        }
        [Obsolete]
        public async void LoadData()
        {
            _allNameDays = await NameDayRepository.GetAllNameDayAsync();
            PerformFiltering();
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

        private string _filter;

        public string Filter
        {
            get { return _filter; }
            set
            {
                if (value == null)
                    return;

                _filter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Filter)));
                PerformFiltering();
            }
        }

        private List<NameDayModel> _allNameDays = new List<NameDayModel>();
        public void PerformFiltering()
        {
            if (_filter == null)
                _filter = "";

            var lowercaseFilter = Filter.ToLowerInvariant().Trim();

            var result = _allNameDays.Where(d => d.NameAsString.ToLowerInvariant().Contains(lowercaseFilter)).ToList();

            var toRemove = NameDays.Except(result).ToList();

            foreach (var x in toRemove)
            {
                NameDays.Remove(x);
            }

            var resultCount = result.Count;
            for (int i = 0; i < resultCount; i++)
            {
                var resultItem = result[i];
                if (i + 1 > NameDays.Count || !NameDays[i].Equals(resultItem))
                    NameDays.Insert(i, resultItem);
            }
        }
        // now it's time for getting the data from cloud but before that we intilize the new sperate barcnh for that.
    }
}
