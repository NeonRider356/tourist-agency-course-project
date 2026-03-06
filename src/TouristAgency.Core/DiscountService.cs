using System;

namespace TouristAgency.Core
{
    public class DiscountService
    {
        public decimal HotTourDiscountPercent { get; }

        public DiscountService(decimal hotTourDiscountPercent = 10m)
        {
            if (hotTourDiscountPercent < 0 || hotTourDiscountPercent > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(hotTourDiscountPercent));
            }

            HotTourDiscountPercent = hotTourDiscountPercent;
        }

        public decimal GetDiscountedPrice(Tour tour)
        {
            return tour.GetActualPrice(HotTourDiscountPercent);
        }

        public bool MarkAsHotIfNeeded(Tour tour, DateTime currentDate)
        {
            var daysBeforeStart = (tour.StartDate.Date - currentDate.Date).TotalDays;
            if (daysBeforeStart <= 7 && daysBeforeStart >= 0 && tour.AvailableSeats > 0)
            {
                tour.IsHot = true;
                tour.Status = TourStatus.Hot;
                return true;
            }

            return false;
        }
    }
}
