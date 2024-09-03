namespace PricingService
{
    public class FastDeliveryPriceDecorator : PriceDecorator
    {
        private readonly decimal _priceMultiplierFactor;

        public FastDeliveryPriceDecorator(IPriceCalculator priceCalculator, decimal priceMultiplierFactor = 2.0m)
            : base(priceCalculator)
        {
            _priceMultiplierFactor = priceMultiplierFactor;
        }

        public override decimal CalculatePrice()
        {
            return (base.CalculatePrice() * _priceMultiplierFactor);
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()} + Speedy Delivery: {_priceMultiplierFactor:C}";
        }
    }
}
