namespace PricingService.Sizes
{
    public class SmallSizeCalculator(IPriceCalculator priceCalculator, decimal charges = PriceConstant.SmallSizePrice) : PriceDecorator(priceCalculator)
    {
        private readonly decimal _charges = charges;   

        public override decimal CalculatePrice()
        {
            return base.CalculatePrice() + _charges;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()} + Small Parcel: {_charges * 0.5m:C}";
        }
    }
}
