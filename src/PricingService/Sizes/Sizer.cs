namespace PricingService.Sizes
{    
    public class Sizer
    {
        public static ParcelSize GetParcelSize(Parcel parcel) => parcel switch
        {
            var s when s.MaxSizeInCentimeter > 0 && s.MaxSizeInCentimeter < PriceConstant.SmallSizeLimit => ParcelSize.Small,
            var s when s.MaxSizeInCentimeter > 0 && s.MaxSizeInCentimeter < PriceConstant.MediumSizeLimit => ParcelSize.Medium,
            var s when s.MaxSizeInCentimeter > 0 && s.MaxSizeInCentimeter < PriceConstant.LargeSizeLimit => ParcelSize.Large,
            var s when s.MaxSizeInCentimeter > PriceConstant.LargeSizeLimit => ParcelSize.XtraLarge,
            _ => throw new ArgumentOutOfRangeException(nameof(parcel), "Size is out of range")
        };

        public static decimal GetParcelCostBySize(ParcelSize size) => size switch
        {
            var s when s == ParcelSize.Small => PriceConstant.SmallSizePrice,
            var s when s == ParcelSize.Medium => PriceConstant.MediumSizePrice,
            var s when s == ParcelSize.Large => PriceConstant.LargeSizePrice,
            var s when s == ParcelSize.XtraLarge => PriceConstant.XtraLargeSizePrice,
            _ => throw new ArgumentOutOfRangeException(nameof(size), "Price is out of range")
        };

        public static PriceDecorator SizeUpParcel(Parcel parcel) => parcel switch
        {
            var s when s.MaxSizeInCentimeter > 0 && s.MaxSizeInCentimeter < PriceConstant.SmallSizeLimit => new SmallSizeCalculator(new BasePrice()),
            var s when s.MaxSizeInCentimeter > 0 && s.MaxSizeInCentimeter < PriceConstant.MediumSizeLimit => new MediumSizeCalculator(new BasePrice()),
            var s when s.MaxSizeInCentimeter > 0 && s.MaxSizeInCentimeter < PriceConstant.LargeSizeLimit => new LargeSizeCalculator(new BasePrice()),
            var s when s.MaxSizeInCentimeter > PriceConstant.LargeSizeLimit => new XtraSizeCalculator(new BasePrice()),
            _ => throw new ArgumentOutOfRangeException(nameof(parcel), "Size is out of range")
        };

        public static decimal GetWeightLimitByParcelSize(Parcel parcel) => parcel switch
        {
            var s when s.SpecialProduct == SpecialProduct.SpecialOnWeight => 50,
            var s when s.MaxSizeInCentimeter > 0 && s.MaxSizeInCentimeter < PriceConstant.SmallSizeLimit => 1,
            var s when s.MaxSizeInCentimeter > 0 && s.MaxSizeInCentimeter < PriceConstant.MediumSizeLimit => 3,
            var s when s.MaxSizeInCentimeter > 0 && s.MaxSizeInCentimeter < PriceConstant.LargeSizeLimit => 6,
            var s when s.MaxSizeInCentimeter > PriceConstant.LargeSizeLimit => 10,
            _ => throw new ArgumentOutOfRangeException(nameof(parcel), "Unsupported parcel dimension size")
        };
    }
}
