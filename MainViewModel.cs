using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Database2024
{
    public class MainViewModel
    {
        private Record _currentRecord = new();

        public UInt32? H_pr 
        {
            get => _currentRecord.H_Pr;
            set 
            {
                _currentRecord.H_Pr = value;
            }
        }
        public UInt32? L_pr
        {
            get => _currentRecord.L_Pr;
            set
            {
                _currentRecord.L_Pr = value;
            }
        }
        public double? Result
        {
            get => _currentRecord.Result;
            set
            {
                _currentRecord.Result = value;
            }
        }

        private ObservableCollection<Record> _records = new ();
        public ObservableCollection<Record> Records => _records;

        public MainViewModel()
        {
            LoadRecords();
            Program.Start(this);
            
        }

        public void AddRecord()
        {
            DbHelper.AddRecord(_currentRecord);
            _records.Add(_currentRecord);
            _currentRecord = new Record();
        }

        private void LoadRecords()
        {
            if (DbHelper.GetRecordsCount() > 0)
            {
                _records.Clear();
                foreach (var user in DbHelper.LoadAll())
                {
                    _records.Add(user);
                }
            }
        }
    }

}
