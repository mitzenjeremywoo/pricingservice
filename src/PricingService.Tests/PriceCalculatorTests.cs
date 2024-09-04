using NUnit.Framework;
using PricingService.Sizes;

namespace PricingService.Tests
{
    public class PriceCalculatorTests
    {
        [Test]
        public void BasicPricingServiceTest()
        {
            decimal weight = 5m;
            decimal discountAmount = 15m;

            var parcelSize = new Parcel(2, 9, weight);

            var calculator = Sizer.SizeUpParcel(parcelSize);
            calculator = new WeightPriceDecorator(calculator, parcelSize);
            calculator = new DiscountPriceDecorator(calculator, discountAmount);
            calculator = new FastDeliveryPriceDecorator(calculator);

            decimal finalPrice = calculator.CalculatePrice();
            string description = calculator.GetDescription();

            Console.WriteLine(description);
            Console.WriteLine($"Final Shipping Cost: {finalPrice:C}");
        }
    }
}
