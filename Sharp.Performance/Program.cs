
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


 

//var some = Benchs[3];


//switch (input)
//{
//    case _ when Benchs[0]:
//        BenchmarkRunner.Run<Iterations>();
//        break;  
//    case Benchs[1]:
//        BenchmarkRunner.Run<LinqBasic>();
//        break;   
//    case Benchs[2]:
//        BenchmarkRunner.Run<LinqBasic>();
//        break;
//} 

