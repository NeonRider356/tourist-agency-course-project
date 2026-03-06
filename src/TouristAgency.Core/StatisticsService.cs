using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristAgency.Core
{
    public class StatisticsService
    {
        public IDictionary<string, int> CountToursByCountrySequential(IEnumerable<Tour> tours)
        {
            return tours
                .GroupBy(t => t.Country)
                .OrderByDescending(g => g.Count())
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public IDictionary<string, int> CountToursByCountryParallel(IEnumerable<Tour> tours)
        {
            var result = new ConcurrentDictionary<string, int>();

            Parallel.ForEach(tours, tour =>
            {
                result.AddOrUpdate(tour.Country, 1, (_, current) => current + 1);
            });

            return result
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
