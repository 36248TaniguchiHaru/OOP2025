namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            SalesCounter sales=new SalesCounter(@"data\sales.csv");
            IDictionary<string,int> amountPerStore= sales.GetPerStoreSales();
            foreach(KeyValuePair<string,int>obj in amountPerStore) {
                Console.WriteLine($"{obj.Key}{obj.Value}");
            }
        }

      



    }
}
