namespace Database2024
{ 
    public class Program 
    {
        private static Storage Storage = new Storage();
        private static Consumer Consumer = new Consumer();
        private static List<Producer> producerList;
        public static void Start(MainViewModel viewModel)
        {
            Producer.storage = Storage; Consumer.storage = Storage;
            producerList = new List<Producer> { new Producer(0), new Producer(1) };
            for (int i = 0; i < producerList.Count; i++) { producerList[i].Start(); }
            Consumer.Start(viewModel);
        }
    }
}
