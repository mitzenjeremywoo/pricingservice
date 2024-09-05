using NUnit.Framework;
using PricingService.Weight;

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

        [Test]
        public void WhenSpecialWeightParceWithinWeightLimitThenPriceChargeApplied()
        {
            var parcelSize = new Parcel(0, 0, 50, SpecialProduct.SpecialOnWeight);
            var calculator = new WeightPriceDecorator(new BasePrice(), parcelSize);
            var result = calculator.CalculatePrice();
            Assert.That(result, Is.EqualTo(0.0m));
        }

        [Test]
        public void WhenSpecialWeightParceÈxceedWeightLimitThenPriceChargeApplied()
        {
            var parcelSize = new Parcel(0, 0, 51, SpecialProduct.SpecialOnWeight);
            var calculator = new WeightPriceDecorator(new BasePrice(), parcelSize);
            var result = calculator.CalculatePrice();
            Assert.That(result, Is.EqualTo(1.0m));
        }

        [Test]
        public void WhenSpecialWeightParceÈxceedWeightLimitTwiceThenPriceChargeApplied()
        {
            var parcelSize = new Parcel(0, 0, 52, SpecialProduct.SpecialOnWeight);
            var calculator = new WeightPriceDecorator(new BasePrice(), parcelSize);
            var result = calculator.CalculatePrice();
            Assert.That(result, Is.EqualTo(2.0m));
        }
    }
}

