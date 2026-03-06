using System;

namespace TouristAgency.Core
{
    public enum TourStatus
    {
        Draft,
        Published,
        Hot,
        Booked,
        Archived
    }

    public class Tour
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public int DurationDays { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsHot { get; set; }
        public int AvailableSeats { get; set; }
        public TourStatus Status { get; set; } = TourStatus.Draft;

        public decimal GetActualPrice(decimal hotDiscountPercent)
        {
            if (IsHot)
            {
                return Math.Round(BasePrice * (1 - hotDiscountPercent / 100m), 2);
            }

            return BasePrice;
        }

        public override string ToString()
        {
            return $"#{Id} {Title} | {Country}, {City} | {StartDate:dd.MM.yyyy} | {DurationDays} дн. | {BasePrice} руб.";
        }
    }
}
