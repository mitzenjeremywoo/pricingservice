namespace PricingService.Sizes
{
    public class LargeSizeCalculator : PriceDecorator
    {
        private readonly decimal _charges;

        public LargeSizeCalculator(IPriceCalculator priceCalculator, decimal charge = 15.0m)
            : base(priceCalculator)
        {
            _charges = charge;
        }

        public override decimal CalculatePrice()
        {
            return base.CalculatePrice() + _charges;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()} + Size Adjustment: {_charges * 0.5m:C}";
        }
    }
}
