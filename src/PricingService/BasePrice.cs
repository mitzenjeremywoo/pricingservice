
namespace PricingService
{
    public class BasePrice : IPriceCalculator
    {
        private readonly decimal _basePrice;

        public BasePrice(decimal basePrice)
        {
            _basePrice = basePrice;
        }

        public decimal CalculatePrice()
        {
            return _basePrice;
        }

        public string GetDescription()
        {
            return $"Base Price: {_basePrice:C}";
        }
    }
}
