using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Database2024
{
    
    class Consumer
    {
        public static Storage storage;
        public void Start(MainViewModel mainViewModel) 
        {
            new Thread(() => 
            {
                double? ex = null;
                while (true) 
                {
                    var result = storage.Get();
                    if (result != null)
                    {
                         ex = (double)(result[0] * result[0] + result[1] * result[1]);
                    }
                    mainViewModel.L_pr = result[0];
                    mainViewModel.H_pr = result[1];
                    mainViewModel.Result = ex;
                    Application.Current.Dispatcher.Invoke(() => mainViewModel.AddRecord());
                }
            }).Start();
        }
    }
}
