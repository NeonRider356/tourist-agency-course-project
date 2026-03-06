using System.Collections.Generic;
using NUnit.Framework;
using TouristAgency.Core;

namespace TouristAgency.Tests
{
    [TestFixture]
    public class StatisticsServiceTests
    {
        [Test]
        public void SequentialAndParallelStatistics_ShouldReturnSameCounts()
        {
            var tours = new List<Tour>
            {
                new Tour { Country = "Турция" },
                new Tour { Country = "Турция" },
                new Tour { Country = "Италия" }
            };

            var service = new StatisticsService();
            var sequential = service.CountToursByCountrySequential(tours);
            var parallel = service.CountToursByCountryParallel(tours);

            CollectionAssert.AreEquivalent(sequential, parallel);
        }
    }
}
