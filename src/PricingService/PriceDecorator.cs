namespace PricingService
{
    public abstract class PriceDecorator : IPriceCalculator
    {
        protected readonly IPriceCalculator _priceCalculator;

        protected PriceDecorator(IPriceCalculator priceCalculator)
        {
            _priceCalculator = priceCalculator;
        }

        public virtual decimal CalculatePrice()
        {
            return _priceCalculator.CalculatePrice();
        }

        public virtual string GetDescription()
        {
            return _priceCalculator.GetDescription();
        }
    }
}
