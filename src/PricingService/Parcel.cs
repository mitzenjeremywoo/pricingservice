namespace PricingService
{
    public class Parcel(decimal minSizeInCentimeter, decimal maxSizeInCentimeter, decimal weightInKgs)
    {
        public decimal MinSizeInCentimeter = minSizeInCentimeter;

        public decimal MaxSizeInCentimeter = maxSizeInCentimeter;
        
        public decimal WeightInKgs = weightInKgs;
    }
}
