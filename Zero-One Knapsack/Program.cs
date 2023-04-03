namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int w1 = 10, w2 = 80;
            // Part 1: create a List of KeyValuePairs.
            var items = new List<KeyValuePair<int, int>>() {
                                                                new KeyValuePair<int, int>(30, 10),
                                                                new KeyValuePair<int, int>(10, 50),
                                                                new KeyValuePair<int, int>(20, 20),
                                                                new KeyValuePair<int, int>(50,150),
                                                                new KeyValuePair<int, int>(40, 80),
                                                                new KeyValuePair<int, int>(25, 200)
                                                            };
            //new KeyValuePair<int, int>(weight, cost)
            //var elelist = new List<List<int>>();
            items = items.OrderBy(o => o.Key).ToList();
            var Cmptn = new List<KeyValuePair<int, int>>();
            var ele = new List<int>();
            Cmptn.Add(new KeyValuePair<int, int>(0, 0));
            ele.Add(0);
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Key > w1) break;
                int sz = Cmptn.Count;
                for (int j = 0; j < sz; j++)
                {
                    if (Cmptn[j].Key + items[i].Key <= w1)
                    {
                        Cmptn.Add(new KeyValuePair<int, int>(Cmptn[j].Key + items[i].Key, Cmptn[j].Value + items[i].Value));
                        ele.Add(i);
                    }
                }
            }
            //int max = list2.Last().Value;
            int maxWeight = 0, maxPrice = 0;
            int maxInx = 0;
            for (int i = 0; i < Cmptn.Count; i++)
            {
                Console.WriteLine(ele[i] + " " + Cmptn[i]);
                if (maxPrice < Cmptn[i].Value)
                {
                    maxWeight = Cmptn[i].Key;
                    maxPrice = Cmptn[i].Value;
                    maxInx = i;
                }
            }
            Console.WriteLine(maxPrice);
            var toDelete = new List<KeyValuePair<int, int>>();
            for (int i = maxInx; i >= 0; i--)
            {
                if (Cmptn[i].Key == maxWeight && Cmptn[i].Value == maxPrice)
                {
                    maxWeight -= items[ele[i]].Key;
                    maxPrice -= items[ele[i]].Value;
                    toDelete.Add(items[ele[i]]);
                }
                if (maxWeight + maxPrice == 0) break;
            }

            for (int i = 0; i < toDelete.Count; i++)
            {
                Console.WriteLine(toDelete[i]);
                items.Remove(toDelete[i]);
            }
            Console.WriteLine("-------------------------------");
            foreach (KeyValuePair<int, int> item in items) { Console.WriteLine(item); }
        }
    }
}