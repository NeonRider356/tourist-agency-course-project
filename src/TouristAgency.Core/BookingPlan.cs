using System.Collections.Generic;
using System.Linq;

namespace TouristAgency.Core
{
    public class BookingPlan
    {
        private readonly List<Tour> _tours = new();

        public IReadOnlyCollection<Tour> Tours => _tours;

        public void AddTour(Tour tour)
        {
            if (_tours.Any(x => x.Id == tour.Id))
            {
                return;
            }

            _tours.Add(tour);
        }

        public void RemoveTour(int tourId)
        {
            var tour = _tours.FirstOrDefault(x => x.Id == tourId);
            if (tour != null)
            {
                _tours.Remove(tour);
            }
        }

        public decimal GetTotal(decimal hotDiscountPercent)
        {
            return _tours.Sum(x => x.GetActualPrice(hotDiscountPercent));
        }
    }
}
