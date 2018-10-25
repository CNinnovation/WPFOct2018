using System.Collections.ObjectModel;

namespace DelayBindingSample
{
    public class SomeData
    {
        public SomeData()
        {
            Info = new ObservableCollection<string>();
            _someText = "init";
        }

        private string _someText;

        public string SomeText
        {
            get { return _someText; }
            set
            {
                Info.Add(value);
                _someText = value;
            }
        }

        public ObservableCollection<string> Info { get; set; }

    }
}
