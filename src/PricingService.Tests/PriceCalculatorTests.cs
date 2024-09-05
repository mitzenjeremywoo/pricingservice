using NUnit.Framework;
using PricingService.Discounts;
using PricingService.Sizes;
using PricingService.Weight;

namespace PricingService.Tests
{
    public class PriceCalculatorTests : BaseTest
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

        [TestCase(6, false, 2)]
        [TestCase(12, true, 2)]
        [TestCase(9, false, 4)]
        [TestCase(15, false, 6)]
        public void TwoSmallParcelWithoutOverweightThenChargeCalcIsSameWithExpected(decimal expectedCharge, bool fastDelivery, int parcelCount)
        {
            var parcels = CreateParcelsTest(parcelCount, 9);
            var totals = new PriceCalculator(parcels, fastDelivery).CalculatePrice();
            Assert.IsTrue(totals.Equals(expectedCharge));
        }

        [TestCase(16, false, 2)]
        [TestCase(32, true, 2)]
        [TestCase(24, false, 4)]
        [TestCase(48, true, 4)]
        [TestCase(32, false, 6)]
        [TestCase(64, true, 6)]
        public void TwoMediumParcelWithoutOverweightThenChargeCalcIsSameWithExpected(decimal expectedCharge, bool fastDelivery, int parcelCount)
        {
            var parcels = CreateParcelsTest(parcelCount, 25);
            var totals = new PriceCalculator(parcels, fastDelivery).CalculatePrice();
            Assert.IsTrue(totals.Equals(expectedCharge));
        }

        [TestCase(30, false, 2)]
        [TestCase(60, true, 2)]
        public void TwoLargeParcelWithoutOverweightThenChargeCalcIsSameWithExpected(decimal expectedCharge, bool fastDelivery, int parcelCount)
        {
            var parcels = CreateParcelsTest(2, 90);
            var totals = new PriceCalculator(parcels, fastDelivery).CalculatePrice();
            Assert.IsTrue(totals.Equals(expectedCharge));
        }

        [TestCase(50, false, 2)]
        [TestCase(100, true, 2)]
        [TestCase(100, false, 5)]
        [TestCase(100, false, 4)]
        public void TwoXtraLargeParcelWithoutOverweightThenChargeCalcIsSameWithExpected(decimal expectedCharge, bool fastDelivery, int parcelCount)
        {
            var parcels = CreateParcelsTest(parcelCount, 125);
            var totals = new PriceCalculator(parcels, fastDelivery).CalculatePrice();
            Assert.IsTrue(totals.Equals(expectedCharge));
        }

        [TestCase(10, false, 2, 2)]
        [TestCase(20, true, 2, 2)]
        [TestCase(17, false, 4, 2)]
        [TestCase(34, true, 4, 2)]
        [TestCase(18, false, 2, 4)]
        public void TwoSmallParcelOverweightThenChargeCalcIsSameWithExpected(decimal expectedCharge, bool fastDelivery, int parcelCount, int weight)
        {
            var parcels = CreateParcelsTest(parcelCount, 9, weight);
            var totals = new PriceCalculator(parcels, fastDelivery).CalculatePrice();
            Assert.IsTrue(totals.Equals(expectedCharge));
        }
    }
}
