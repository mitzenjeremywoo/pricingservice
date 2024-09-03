using NUnit.Framework;

namespace PricingService.Tests
{
    public class PriceCalculatorTests
    {

        [Test]
        public void BasicPricingServiceTest()
        {
            decimal basePrice = 100m;
            decimal size = 10m;
            decimal weight = 5m;
            decimal discountAmount = 15m;

            IPriceCalculator calculator = new BasePrice(basePrice);
            //calculator = new SizePriceDecorator(calculator, size);
            calculator = new WeightPriceDecorator(calculator, weight);
            calculator = new DiscountPriceDecorator(calculator, discountAmount);

            decimal finalPrice = calculator.CalculatePrice();
            string description = calculator.GetDescription();

            Console.WriteLine(description);
            Console.WriteLine($"Final Shipping Cost: {finalPrice:C}");
        }
    }
}
