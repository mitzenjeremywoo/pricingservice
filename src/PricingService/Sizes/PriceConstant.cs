namespace PricingService.Sizes
{
    internal class PriceConstant
    {
        // Price charges for different sizes
        internal const decimal SmallSizePrice = 3.0m;
        internal const decimal MediumSizePrice = 8.0m;
        internal const decimal LargeSizePrice = 15.0m;
        internal const decimal XtraLargeSizePrice = 25.0m;

        // Size constant for different sizes
        internal const decimal SmallSizeLimit = 10.0m;
        internal const decimal MediumSizeLimit = 50.0m;
        internal const decimal LargeSizeLimit = 100.0m;

        internal const decimal ExcessWeightChargePerKg = 2.0m;
    }
}
