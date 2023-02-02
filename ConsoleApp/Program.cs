public class Program
{
    public static void Main()
    {
        var c = new Test();

        //var report = c.GetType().GetProperty()
        //Console.WriteLine(report);

        for (int i = 0; i < 5; i++)
        {
            var str = Console.ReadLine();
            Console.WriteLine(c[str]);
        }
    }
}

public class City
{
    public string Name { get; init; }
    public int Population { get; init; }
}

public class Test
{
    private readonly IDictionary<string, City> _dic;

    public Test()
    {
        _dic = new Dictionary<string, City> {
            {"Moscow", new City { Name = "Moscow", Population = 8000000 } },
            {"Perm", new City { Name = "Perm", Population = 1500000 }}
        };
    }

    public int Samara => 5000000;

    public int this[string index]
    {
        get {
            if (_dic != null && _dic.ContainsKey(index))
            {
                return _dic[index].Population;
            }
            return 0;
        }
    }
}