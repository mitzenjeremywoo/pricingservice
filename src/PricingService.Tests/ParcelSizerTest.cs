using NUnit.Framework;
using PricingService.Sizes;

namespace PricingService.Tests
{
    public class ParcelSizerTest
    {        
        [Test]
        public void WhenParcelSizeWithinSmallRangeThenReturnAppropriateCalculator()
        {
            var parcelSize = new Parcel(2, 9, 1);
            var instance = Sizer.SizeUpParcel(parcelSize);
            Assert.IsInstanceOf<SmallSizeCalculator>(instance);
        }

        [Test]
        public void WhenParcelSizeWithinMediumRangeThenReturnAppropriateCalculator()
        {
            var parcelSize = new Parcel(2, 10, 1);
            var instance = Sizer.SizeUpParcel(parcelSize);
            Assert.IsInstanceOf<MediumSizeCalculator>(instance);
        }

        [Test]
        public void WhenParcelSizeWithinLargeRangeThenReturnAppropriateCalculator()
        {
            var parcelSize = new Parcel(2, 52, 1);
            var instance = Sizer.SizeUpParcel(parcelSize);
            Assert.IsInstanceOf<LargeSizeCalculator>(instance);
        }
    }
}
