using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Tests;
using PrExt;

namespace Benchmarks;

public class Program
{
    //dotnet run --project Prext.BenchMark.csproj -c Release
    private static void Main(string[] args)
    {
        BenchmarkRunner.Run<KoldingBencher>();
        BenchmarkRunner.Run<NordsoeBencher>();
    }
}

public class KoldingBencher
{
    private readonly string _testDataPath =
        @$"{Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.Parent?.Parent?.Parent?.Parent?.FullName}/Prext.Tests";

    private static Dictionary<string, (List<Interval> intervals, Dictionary<int, int> colorMap)> _koldingData = new();

    
    [Params("10 m2 4pers u/udstyr", "15 m2 4pers", "17 m2 4pers", "25 m2 6pers", "Teltpladser",
        "Campingvogn fortelt", "Elplads", "2 pers. Hytte m. udstyr")]
    public string KoldingCamp;

    [GlobalSetup]
    public void Setup()
    {
        _koldingData[KoldingCamp] = TestDataLoader.LoadIntervalsFromDataSet("kolding", KoldingCamp, _testDataPath);
    }

    [Benchmark]
    public void Prext() =>
        IntervalFitter.Prext(_koldingData[KoldingCamp].intervals, _koldingData[KoldingCamp].colorMap);
}

public class NordsoeBencher
{
    private readonly string _testDataPath =
        @$"{Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.Parent?.Parent?.Parent?.Parent?.FullName}/Prext.Tests";

    private static Dictionary<string, (List<Interval> intervals, Dictionary<int, int> colorMap)> _nordsoeData = new();


    [Params("Hytte 08m2", "Hytte 12m2","Hytte 16m2", "Hytte 20m2", "Hytte 25m2", "Teltplads", "Komfortplads")]
    public string NordsoeCamp;

    [GlobalSetup]
    public void Setup()
    {
        _nordsoeData[NordsoeCamp] = TestDataLoader.LoadIntervalsFromDataSet("nordsoe", NordsoeCamp, _testDataPath);
    }

    [Benchmark]
    public void Prext() =>
        IntervalFitter.Prext(_nordsoeData[NordsoeCamp].intervals, _nordsoeData[NordsoeCamp].colorMap);
}