using System;
using System.Collections.Generic;

namespace TouristAgency.Core
{
    public static class SampleDataFactory
    {
        public static List<Tour> CreateTours()
        {
            return new List<Tour>
            {
                new Tour { Id = 1, Title = "Анталья Light", Country = "Турция", City = "Анталья", StartDate = DateTime.Today.AddDays(5), DurationDays = 7, BasePrice = 85000m, AvailableSeats = 4, Status = TourStatus.Published },
                new Tour { Id = 2, Title = "Dubai Weekend", Country = "ОАЭ", City = "Дубай", StartDate = DateTime.Today.AddDays(14), DurationDays = 5, BasePrice = 132000m, AvailableSeats = 2, Status = TourStatus.Published },
                new Tour { Id = 3, Title = "Rome Classic", Country = "Италия", City = "Рим", StartDate = DateTime.Today.AddDays(20), DurationDays = 6, BasePrice = 118000m, AvailableSeats = 5, Status = TourStatus.Published },
                new Tour { Id = 4, Title = "Phuket Summer", Country = "Таиланд", City = "Пхукет", StartDate = DateTime.Today.AddDays(6), DurationDays = 10, BasePrice = 156000m, AvailableSeats = 3, Status = TourStatus.Published },
                new Tour { Id = 5, Title = "Sharm Relax", Country = "Египет", City = "Шарм-эль-Шейх", StartDate = DateTime.Today.AddDays(3), DurationDays = 8, BasePrice = 91000m, AvailableSeats = 6, Status = TourStatus.Published },
            };
        }
    }
}
