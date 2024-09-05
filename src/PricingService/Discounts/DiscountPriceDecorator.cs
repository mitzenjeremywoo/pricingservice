namespace PricingService.Discounts
{
    public class DiscountPriceDecorator : PriceDecorator
    {
        private readonly decimal _discountAmount;

        public DiscountPriceDecorator(IPriceCalculator priceCalculator, decimal discountAmount)
            : base(priceCalculator)
        {
            _discountAmount = discountAmount;
        }

        public override decimal CalculatePrice()
        {
            return base.CalculatePrice() - _discountAmount;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()} - Discount: {_discountAmount:C}";
        }
    }
}
