using NUnit.Framework;
using PricingService.Sizes;

namespace PricingService.Tests
{
    public class SizeCalculatorTests
    {
        [Test]
        public void WhenSmallSizeCalculatorThenPriceIs3Test()
        {
            decimal basePrice = 0.0m;
            decimal expectedSmallPrice = 3.0m;
            IPriceCalculator baseCalculator = new BasePrice(basePrice);
            baseCalculator = new SmallSizeCalculator(baseCalculator);
            var result = baseCalculator.CalculatePrice();

            Assert.That(result, Is.EqualTo(expectedSmallPrice));
        }

        [Test]
        public void WhenMediumSizeCalculatorThenPriceIs8Test()
        {
            decimal basePrice = 0.0m;
            decimal expectedMediumPrice = 8.0m;
            IPriceCalculator baseCalculator = new BasePrice(basePrice);
            baseCalculator = new MediumSizeCalculator(baseCalculator);
            var result = baseCalculator.CalculatePrice();

            Assert.That(result, Is.EqualTo(expectedMediumPrice));
        }

        [Test]
        public void WhenLargeSizeCalculatorPriceIs15Test()
        {
            decimal basePrice = 0.0m;
            decimal expectedLargePrice = 15.0m;
            IPriceCalculator calculator = new BasePrice(basePrice);
            calculator = new LargeSizeCalculator(calculator);
            var result = calculator.CalculatePrice();

            Assert.That(result, Is.EqualTo(expectedLargePrice));
        }

        [Test]
        public void WhenXtraLargeSizeCalculatorThenPriceIs25Test()
        {
            decimal basePrice = 0.0m;
            decimal expectedXtraLargePrice = 25.0m;
            IPriceCalculator calculator = new BasePrice(basePrice);
            calculator = new XtraSizeCalculator(calculator);
            var result = calculator.CalculatePrice();

            Assert.That(result, Is.EqualTo(expectedXtraLargePrice));
        }
    }
}
