using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Database2024
{
    public class Record
    {
        public uint? H_Pr { get; set; }
        public uint? L_Pr { get; set; }
        public double? Result { get; set; }

        public Record()
        {
            Clear();
        }
        private Record(uint h_pr, uint l_pr, double result)
        {
            H_Pr = h_pr;
            L_Pr = l_pr;
            Result = result;
        }

        public void Clear()
        {
            H_Pr = null ;
            L_Pr = null;
            Result = null;
        }
    }
}
