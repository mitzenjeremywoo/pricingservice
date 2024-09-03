namespace PricingService.Sizes
{
    public class MediumSizeCalculator(IPriceCalculator priceCalculator, decimal charges = PriceConstant.MediumSizePrice) : PriceDecorator(priceCalculator)
    {
        private readonly decimal _charges = charges;

        //public MediumSizeCalculator(IPriceCalculator priceCalculator, decimal charges = PriceConstant.MediumSizePrice)
        //    : base(priceCalculator)
        //{
        //    _charges = charges;
        //}

        public override decimal CalculatePrice()
        {
            return base.CalculatePrice() + _charges;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()} + Medium Parcel: {_charges:C}";
        }
    }
}
