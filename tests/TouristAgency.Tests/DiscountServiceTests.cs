using System;
using NUnit.Framework;
using TouristAgency.Core;

namespace TouristAgency.Tests
{
    [TestFixture]
    public class DiscountServiceTests
    {
        [Test]
        public void GetDiscountedPrice_ShouldApplyDiscount_ForHotTour()
        {
            var service = new DiscountService(10m);
            var tour = new Tour
            {
                BasePrice = 100000m,
                IsHot = true
            };

            var result = service.GetDiscountedPrice(tour);

            Assert.AreEqual(90000m, result);
        }

        [Test]
        public void MarkAsHotIfNeeded_ShouldMarkTour_WhenStartIsWithinSevenDays()
        {
            var service = new DiscountService();
            var tour = new Tour
            {
                StartDate = DateTime.Today.AddDays(2),
                AvailableSeats = 2,
                Status = TourStatus.Published
            };

            var changed = service.MarkAsHotIfNeeded(tour, DateTime.Today);

            Assert.IsTrue(changed);
            Assert.IsTrue(tour.IsHot);
            Assert.AreEqual(TourStatus.Hot, tour.Status);
        }
    }
}
