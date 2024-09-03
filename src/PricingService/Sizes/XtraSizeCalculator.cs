namespace PricingService.Sizes
{
    public class XtraSizeCalculator(IPriceCalculator priceCalculator, decimal charges = PriceConstant.XtraLargeSizePrice) : PriceDecorator(priceCalculator)
    {
        private readonly decimal _charges = charges;     

        public override decimal CalculatePrice()
        {
            return base.CalculatePrice() + _charges;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()} + Xtra Large Parcel: {_charges:C}";
        }
    }
}
