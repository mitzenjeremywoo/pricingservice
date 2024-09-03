namespace PricingService.Sizes
{
    public class ParcelSize(decimal min, decimal max)
    {
        public decimal MinSizeInCentimeter = min;
        public decimal MaxSizeInCentimeter = max;
    }
}
