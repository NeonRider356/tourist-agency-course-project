namespace TouristAgency.Utils
{
    public static class PriceHelper
    {
        public static decimal CalculateAgencyFee(decimal amount, decimal percent)
        {
            return amount * percent / 100m;
        }
    }
}
