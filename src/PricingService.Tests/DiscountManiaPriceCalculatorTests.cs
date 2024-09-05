using NUnit.Framework;
using PricingService.Discounts;

namespace PricingService.Tests
{
    public class DiscountManiaPriceCalculatorTests : BaseTest
    {
        [Test]
        public void WhenSmallParcelManiaDiscountAppliedThenFree1()
        {
            var parcels = CreateParcelsTest(4, 9);
            var cost = new ManiaCalculator().CalculateTotalCost(parcels);
            Assert.IsTrue(cost.Equals(3.0m));
        }

        [Test]
        public void WhenSmallParcelManiaDiscountCriteriaNotMeetThenNormalChargeApplid()
        {
            var parcels = CreateParcelsTest(3, 9);
            var cost = new ManiaCalculator().CalculateTotalCost(parcels);
            Assert.IsTrue(cost.Equals(0.0m));
        }

        [Test]
        public void WhenMediumParcelManiaDiscountAppliedThenFree1()
        {            
            var parcels = CreateParcelsTest(4, 22);
            var cost = new ManiaCalculator().CalculateTotalCost(parcels);
            Assert.IsTrue(cost.Equals(8.0m));
        }

        [Test]
        public void WhenMediumParcelManiaDiscountAppliedThenFreeTwo()
        {
            var parcels = CreateParcelsTest(6, 22);
            var cost = new ManiaCalculator().CalculateTotalCost(parcels);
            Assert.IsTrue(cost.Equals(16.0m));
        }

        [Test]
        public void WhenMediumParcelManiaDiscountNotAppliedThenNoFree()
        {
            var parcels = CreateParcelsTest(2, 22);
            var cost = new ManiaCalculator().CalculateTotalCost(parcels);
            Assert.IsTrue(cost.Equals(0.0m));
        }

        [Test]
        public void WhenMixSmallMediumParcelManiaDiscountAppliedThenFree()
        {
            var small = CreateParcelsTest(4, 9);
            var medium = CreateParcelsTest(4, 22);

            var parcels = new List<Parcel>();
            parcels.AddRange(small);
            parcels.AddRange(medium);

            var cost = new ManiaCalculator().CalculateTotalCost(parcels);
            Assert.IsTrue(cost.Equals(11.0m));
        }        
    }
}
