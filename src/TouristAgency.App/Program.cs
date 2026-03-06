using System;
using System.Collections.Generic;
using System.Diagnostics;
using TouristAgency.Core;

namespace TouristAgency.App
{
    internal class Program
    {
        private static void Main()
        {
            var tours = SampleDataFactory.CreateTours();
            var discountService = new DiscountService(12m);
            var statisticsService = new StatisticsService();
            var bookingPlan = new BookingPlan();

            Console.WriteLine("=== Туристическое агентство ===");
            Console.WriteLine("Доступные туры:");

            foreach (var tour in tours)
            {
                discountService.MarkAsHotIfNeeded(tour, DateTime.Today);
                Console.WriteLine($"{tour} | статус: {tour.Status} | цена с учетом скидки: {discountService.GetDiscountedPrice(tour)}");
            }

            bookingPlan.AddTour(tours[0]);
            bookingPlan.AddTour(tours[3]);

            Console.WriteLine();
            Console.WriteLine("План отдыха посетителя:");
            foreach (var tour in bookingPlan.Tours)
            {
                Console.WriteLine($"- {tour.Title}");
            }
            Console.WriteLine($"Итоговая стоимость: {bookingPlan.GetTotal(discountService.HotTourDiscountPercent)} руб.");

            Console.WriteLine();
            Console.WriteLine("Статистика по странам (последовательный вариант):");
            foreach (var item in statisticsService.CountToursByCountrySequential(tours))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Benchmark(statisticsService);
        }

        private static void Benchmark(StatisticsService statisticsService)
        {
            var randomTours = GenerateLargeDataset(200000);

            var sw1 = Stopwatch.StartNew();
            statisticsService.CountToursByCountrySequential(randomTours);
            sw1.Stop();

            var sw2 = Stopwatch.StartNew();
            statisticsService.CountToursByCountryParallel(randomTours);
            sw2.Stop();

            Console.WriteLine();
            Console.WriteLine("Сравнение производительности:");
            Console.WriteLine($"Последовательно: {sw1.ElapsedMilliseconds} мс");
            Console.WriteLine($"Параллельно: {sw2.ElapsedMilliseconds} мс");
        }

        private static List<Tour> GenerateLargeDataset(int count)
        {
            var countries = new[] { "Турция", "ОАЭ", "Италия", "Таиланд", "Египет", "Испания", "Греция" };
            var result = new List<Tour>(count);
            var random = new Random(42);

            for (var i = 0; i < count; i++)
            {
                var country = countries[random.Next(countries.Length)];
                result.Add(new Tour
                {
                    Id = i + 1,
                    Title = $"Tour {i + 1}",
                    Country = country,
                    City = "City",
                    StartDate = DateTime.Today.AddDays(random.Next(1, 90)),
                    DurationDays = random.Next(3, 14),
                    BasePrice = random.Next(70000, 180000),
                    AvailableSeats = random.Next(1, 10),
                    Status = TourStatus.Published
                });
            }

            return result;
        }
    }
}
