using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database2024
{
    public class Storage
    {
        private List<uint?> _data = new List<uint?>();
        public Storage() 
        {
            _data.Add(null);
            _data.Add(null);
        }

        public void Put(int index,uint value) 
        {
            lock (_data)
            {
                _data[index] = value;
                Monitor.PulseAll(_data);
            }
        }

        public List<uint?> Get() 
        {
            List<uint?> ints = new List<uint?>();
            ints.Add(null);ints.Add(null);
            lock (_data) 
            {
                while (_data.Contains(null)) 
                {
                    Monitor.Wait(_data);
                }
                for (int i = 0; i < _data.Count; i++) ints[i] = _data[i];
                _data[0] = _data[1] = null;
            }
            return ints;
        }
    }
}
