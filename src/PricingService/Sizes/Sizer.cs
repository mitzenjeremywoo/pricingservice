namespace PricingService.Sizes
{
    public class Sizer
    {     
        public static PriceDecorator SizeUpParcel(ParcelSize parcel) => parcel switch
        {
            var s when s.MinSizeInCentimeter > 0 && s.MaxSizeInCentimeter < 10 => new SmallSizeCalculator(new BasePrice()),
            var s when s.MinSizeInCentimeter > 0 && s.MaxSizeInCentimeter < 50 => new MediumSizeCalculator(new BasePrice()),
            var s when s.MinSizeInCentimeter > 0 && s.MaxSizeInCentimeter < 100 => new LargeSizeCalculator(new BasePrice()),
            var s when s.MinSizeInCentimeter > 100 => new XtraSizeCalculator(new BasePrice()),
            _ => throw new ArgumentOutOfRangeException(nameof(parcel), "Size is out of range")
        };
    }
}
