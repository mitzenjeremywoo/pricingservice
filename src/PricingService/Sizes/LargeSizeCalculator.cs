namespace PricingService.Sizes
{
    public class LargeSizeCalculator(IPriceCalculator priceCalculator, decimal charges = PriceConstant.LargeSizePrice) : PriceDecorator(priceCalculator)
    {
        private readonly decimal _charges = charges;    

        public override decimal CalculatePrice()
        {
            return base.CalculatePrice() + _charges;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()} + Large Parcel: {_charges:C}";
        }
    }
}
