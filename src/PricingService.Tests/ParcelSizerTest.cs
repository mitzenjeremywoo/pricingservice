using NUnit.Framework;
using PricingService.Sizes;

namespace PricingService.Tests
{
    public class ParcelSizerTest
    {        
        [Test]
        public void WhenParcelSizeWithinSmallRangeThenReturnAppropriateCalculator()
        {
            var parcelSize = new ParcelSize(2, 9);
            var instance = Sizer.SizeUpParcel(parcelSize);
            Assert.IsInstanceOf<SmallSizeCalculator>(instance);
        }

        [Test]
        public void WhenParcelSizeWithinMediumRangeThenReturnAppropriateCalculator()
        {
            var parcelSize = new ParcelSize(2, 10);
            var instance = Sizer.SizeUpParcel(parcelSize);
            Assert.IsInstanceOf<MediumSizeCalculator>(instance);
        }

        [Test]
        public void WhenParcelSizeWithinLargeRangeThenReturnAppropriateCalculator()
        {
            var parcelSize = new ParcelSize(2, 52   );
            var instance = Sizer.SizeUpParcel(parcelSize);
            Assert.IsInstanceOf<LargeSizeCalculator>(instance);
        }

    }
}
