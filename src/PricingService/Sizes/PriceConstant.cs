namespace PricingService.Sizes
{
    public class PriceConstant
    {
        // Price charges for different sizes
        public const decimal SmallSizePrice = 3.0m;
        public const decimal MediumSizePrice = 8.0m;
        public const decimal LargeSizePrice = 15.0m;
        public const decimal XtraLargeSizePrice = 25.0m;

        // Size constant for different sizes
        public const decimal SmallSizeLimit = 10.0m;
        public const decimal MediumSizeLimit = 50.0m;
        public const decimal LargeSizeLimit = 100.0m;

        public const decimal SpecialSizeLimit = 200.0m;

        public const decimal ExcessWeightChargePerKg = 2.0m;
        public const decimal SpecialExcessWeightChargePerKg = 1.0m;

    }
}
