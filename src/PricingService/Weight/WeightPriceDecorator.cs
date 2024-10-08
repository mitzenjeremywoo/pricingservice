﻿using PricingService.Sizes;

namespace PricingService.Weight
{
    public class WeightPriceDecorator : PriceDecorator
    {
        private decimal _priceCalculation;
        private readonly Parcel _parcel;

        public WeightPriceDecorator(IPriceCalculator priceCalculator, Parcel parcel)
            : base(priceCalculator)
        {
            _parcel = parcel;
        }

        public decimal CalculateOverweightCharge(Parcel parcel)
        {
            decimal overweightCharge = 0;
            decimal weightLimit = GetWeightLimit(parcel);

            if (parcel.WeightInKgs > weightLimit)
            {
                decimal excessWeight = parcel.WeightInKgs - weightLimit;

                overweightCharge = parcel.SpecialProduct == SpecialProduct.SpecialOnWeight ? excessWeight * PriceConstant.SpecialExcessWeightChargePerKg : excessWeight * PriceConstant.ExcessWeightChargePerKg;
            }
            return overweightCharge;
        }

        public override decimal CalculatePrice()
        {
            _priceCalculation = CalculateOverweightCharge(_parcel);
            return base.CalculatePrice() + _priceCalculation;
        }
        public override string GetDescription()
        {
            return $"{base.GetDescription()} + Extra charge weight: {_priceCalculation:C}";
        }
        private decimal GetWeightLimit(Parcel parcel)
        {
            return Sizer.GetWeightLimitByParcelSize(parcel);
        }
    }
}
