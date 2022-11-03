
using BenchmarkDotNet.Running;
using Sharp.Performance;
string input = Environment.GetCommandLineArgs()[1];


if (Enum.TryParse(input, true, out Benchmark benchmark))
{
    if(benchmark.Equals(Benchmark.Iteration))
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
    Iteration,
    Linq,
    LinqComplex,
    
}


