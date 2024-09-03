namespace PricingService.Sizes
{
    public class MediumSizeCalculator : PriceDecorator
    {
        private readonly decimal _charges;

        public MediumSizeCalculator(IPriceCalculator priceCalculator, decimal charges = 8.0m)
            : base(priceCalculator)
        {
            _charges = charges;
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
