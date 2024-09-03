namespace PricingService
{
    public class SizePriceDecorator : PriceDecorator
    {
        private readonly decimal _size;

        public SizePriceDecorator(IPriceCalculator priceCalculator, decimal size)
            : base(priceCalculator)
        {
            _size = size;
        }

        public override decimal CalculatePrice()
        {
            var additionalCost = _size * 0.5m; 
            return base.CalculatePrice() + additionalCost;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()} + Size Adjustment: {_size * 0.5m:C}";
        }
    }
}
