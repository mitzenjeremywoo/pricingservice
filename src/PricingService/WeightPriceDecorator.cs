namespace PricingService
{
    public class WeightPriceDecorator : PriceDecorator
    {
        private readonly decimal _weight;

        public WeightPriceDecorator(IPriceCalculator priceCalculator, decimal weight)
            : base(priceCalculator)
        {
            _weight = weight;
        }

        public override decimal CalculatePrice()
        {
            var additionalCost = _weight * 0.3m; // Example calculation
            return base.CalculatePrice() + additionalCost;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()} + Weight Adjustment: {_weight * 0.3m:C}";
        }
    }
}
