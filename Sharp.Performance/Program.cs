
using BenchmarkDotNet.Running;
using Sharp.Performance;
string input = Environment.GetCommandLineArgs()[1];


if (Enum.TryParse(input, true, out Benchmark benchmark))
{
    if(benchmark.Equals(Benchmark.Iteraton))
    {
        BenchmarkRunner.Run<Iterations>();
    }

    if(benchmark.Equals(Benchmark.Linq))
    {
        BenchmarkRunner.Run<LinqBasic>();
    }

    if(benchmark.Equals(Benchmark.LinqComplex))
    {
        BenchmarkRunner.Run<LinqComplex>();
    }    
}
else
{
    Console.WriteLine("Invalid parameter input, execution done...");
}





public enum Benchmark
{
    Iteraton,
    Linq,
    LinqComplex,
    
}


