using NUnit.Framework;
using TouristAgency.Core;

namespace TouristAgency.Tests
{
    [TestFixture]
    public class BookingPlanTests
    {
        [Test]
        public void GetTotal_ShouldReturnSumOfAllTours()
        {
            var plan = new BookingPlan();
            plan.AddTour(new Tour { Id = 1, BasePrice = 50000m, IsHot = false });
            plan.AddTour(new Tour { Id = 2, BasePrice = 100000m, IsHot = true });

            var total = plan.GetTotal(10m);

            Assert.AreEqual(140000m, total);
        }
    }
}
