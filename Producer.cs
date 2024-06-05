using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database2024
{
    class Producer
    {
        public static Storage storage;
        private Random random = new Random();
        private int id;

        public Producer(int id)
        {
            this.id = id;
        }
        public void Start()
        {
            new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(random.Next(1000, 10000));
                    var res = random.Next(1, 100);
                    storage.Put(id, (uint)res);
                }
            }).Start();
        }
    }
}
