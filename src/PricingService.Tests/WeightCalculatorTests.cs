using NUnit.Framework;

namespace PricingService.Tests
{
    public class WeightCalculatorTests
    {
        [Test]
        public void WhenSmallParceWithinWeightLimitThenPriceChargeApplied()
        {
            var parcelSize = new Parcel(2, 9, 1);
            var calculator = new WeightPriceDecorator(new BasePrice(), parcelSize);
            var result = calculator.CalculatePrice();
            Assert.That(result, Is.EqualTo(0.0m));
        }

        [Test]
        public void WhenSmallParceExceedWeightLimitThenPriceChargeApplied()
        {
            var parcelSize = new Parcel(2, 9, 3);
            var calculator = new WeightPriceDecorator(new BasePrice(), parcelSize);
            var result = calculator.CalculatePrice();
            Assert.That(result, Is.EqualTo(4.0m));
        }

        [Test]
        public void WhenMediumParceExceedWeightLimitThenPriceChargeApplied()
        {
            var parcelSize = new Parcel(2, 30, 4);
            var calculator = new WeightPriceDecorator(new BasePrice(), parcelSize);
            var result = calculator.CalculatePrice();
            Assert.That(result, Is.EqualTo(2.0m));
        }

        [Test]
        public void WhenMediumParceWithinWeightLimitThenPriceChargeApplied()
        {
            var parcelSize = new Parcel(2, 30, 3);
            var calculator = new WeightPriceDecorator(new BasePrice(), parcelSize);
            var result = calculator.CalculatePrice();
            Assert.That(result, Is.EqualTo(0.0m));
        }

    }
}

