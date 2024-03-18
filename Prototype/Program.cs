namespace Prototype;

internal class Program {
    static void Main(string[] args) {
        var listType=typeof(Brimborium.TheMeaningOfLiff.ValueDatum<>).Assembly.GetTypes().Where(t=>t.IsPublic).ToList();
        foreach (var line in Extract.Get(listType)) {
            Console.WriteLine(line);
        }
    }
}
