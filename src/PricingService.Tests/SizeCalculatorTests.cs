using NUnit.Framework;
using PricingService.Sizes;

namespace PricingService.Tests
{
    public class SizeCalculatorTests
    {
        [Test]
        public void SmallSizeCalculatorTest()
        {
            decimal basePrice = 0.0m;
            decimal expectedSmallPrice = 3.0m;
            IPriceCalculator calculator = new BasePrice(basePrice);
            calculator = new SmallSizeCalculator(calculator);
            var result = calculator.CalculatePrice();

            Assert.That(result, Is.EqualTo(expectedSmallPrice));
        }

        [Test]
        public void MediumSizeCalculatorTest()
        {
            decimal basePrice = 0.0m;
            decimal expectedSmallPrice = 8.0m;
            IPriceCalculator calculator = new BasePrice(basePrice);
            calculator = new MediumSizeCalculator(calculator);
            var result = calculator.CalculatePrice();

            Assert.That(result, Is.EqualTo(expectedSmallPrice));
        }

        [Test]
        public void LargeSizeCalculatorTest()
        {
            decimal basePrice = 0.0m;
            decimal expectedSmallPrice = 15.0m;
            IPriceCalculator calculator = new BasePrice(basePrice);
            calculator = new LargeSizeCalculator(calculator);
            var result = calculator.CalculatePrice();

            Assert.That(result, Is.EqualTo(expectedSmallPrice));
        }

        [Test]
        public void XtraLargeSizeCalculatorTest()
        {
            decimal basePrice = 0.0m;
            decimal expectedSmallPrice = 25.0m;
            IPriceCalculator calculator = new BasePrice(basePrice);
            calculator = new XtraSizeCalculator(calculator);
            var result = calculator.CalculatePrice();

            Assert.That(result, Is.EqualTo(expectedSmallPrice));
        }
    }
}
