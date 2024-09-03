namespace PricingService.Sizes
{
    internal class PriceConstant
    {
        internal const decimal SmallSizePrice = 3.0m;
        internal const decimal MediumSizePrice = 8.0m;
        internal const decimal LargeSizePrice = 15.0m;
        internal const decimal XtraLargeSizePrice = 25.0m;
    }

    public class ParcelSizer(decimal parcelDimension)
    {

    }

}
