using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Bogus;

namespace Sharp.Performance
{
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [MemoryDiagnoser(false)]
    public class LinqComplex
    {
        [Params(100,100_000,1000_000)]
        public int Size { get; set; }

        private readonly Faker<User> _faker = new();

        private List<User> _users;

        public LinqComplex()
        {
            _users = _faker
                .RuleFor(drink => 
                    drink.Name
                  , faker => faker.Name.FullName()
                )
                .RuleFor(drink => 
                  drink.IsActive
                  , faker => faker.Random.Bool(0.5f)
                 )
                .Generate(Size);
        }


        [Benchmark]
        public int ActiveUsersCountLinqWhere() => ActiveUsers_Where();

        [Benchmark]
        public int ActiveUsersCountLinqCount() => ActiveUsers_Count();

        [Benchmark]
        public int ActiveUsersCountForLoop() => ActiveUsers_For();

        [Benchmark]
        public int ActiveUsersCountForEachLoop() => ActiveUsers_ForEach();

        [Benchmark]
        public List<string> NonActiveUsersNamesForLoop() => NonActiveUserNames_For();

        [Benchmark]
        public List<string> NonActiveUsersNamesLinq() => NonActiveUsersNames_Linq();




        public int ActiveUsers_Where()
        {
            return _users
                .Where(x => x.IsActive)
                .Count();
        }

        public int ActiveUsers_Count()
        {
            return _users.Count(x => x.IsActive);
        }

        public int ActiveUsers_For()
        {
            var count = 0;
            for (var i = 0; i < _users.Count; i++)
            {
                if (_users[i].IsActive)
                {
                    count++;
                }
            }
            return count;
        }

        public int ActiveUsers_ForEach()
        {
            var count = 0;
            foreach (var drink in _users)
            {
                if (drink.IsActive)
                {
                    count++;
                }
            }
            return count;
        }

        public List<string> NonActiveUserNames_For()
        {
            var names = new List<string>();
            for (var i = 0; i < _users.Count; i++)
            {
                var drink = _users[i];
                if (!_users[i].IsActive)
                {
                    names.Add(drink.Name!);
                }
            }
            return names;
        }

        public List<string> NonActiveUsersNames_Linq()
        {
            return _users!
                .Where(x => !x.IsActive)
                .Select(x => x.Name!)
                .ToList();
        }



#if NET6_0
        //Do something
#endif

#if NET7_0
        //Do something
#endif

    }
}
