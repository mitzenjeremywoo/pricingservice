namespace PricingService
{

    public class Parcel(decimal minSizeInCentimeter, decimal maxSizeInCentimeter, decimal weightInKgs, SpecialProduct specialProduct = SpecialProduct.Normal)
    {
        public decimal MinSizeInCentimeter = minSizeInCentimeter;

        public decimal MaxSizeInCentimeter = maxSizeInCentimeter;
        
        public decimal WeightInKgs = weightInKgs;

        public SpecialProduct SpecialProduct = specialProduct;
    }
}
