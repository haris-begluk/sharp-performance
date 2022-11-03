using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Sharp.Performance
{
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [MemoryDiagnoser(false)]
    public class LinqBasic
    {
        [Params(100)]
        public int Size { get; set; }

        private IEnumerable<int>? _collection;

        [GlobalSetup] 
        public void Setup()
        {
            _collection = Enumerable
                .Range(0, Size)
                .ToArray();
        }
        [Benchmark]
        public int Max() => _collection!.Max();

        [Benchmark]
        public int Min() => _collection!.Min();

        [Benchmark]
        public double Average() => _collection!.Average();

        [Benchmark]
        public int Sum() => _collection!.Sum();


        #if NET6_0 
        //Do something
        #endif 

        #if NET7_0 
        //Do something
        #endif
     
    }
}
