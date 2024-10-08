﻿using PricingService.Discounts;
using PricingService.Sizes;
using PricingService.Weight;

namespace PricingService
{
    public class PriceCalculator(IEnumerable<Parcel> parcels, bool fastDelivery = true)
    {
        IEnumerable<Parcel> _parcels = parcels;
        bool _fastDelivery = fastDelivery; 

        public decimal CalculatePrice()
        {
            if (_parcels != null && _parcels.Count() > 0)
            {
                IPriceCalculator calculator = new BasePrice();
                decimal subTotal = 0m;

                foreach (var parcel in _parcels)
                {
                    calculator = Sizer.SizeUpParcel(Sizer.GetParcelSize(parcel));
                    calculator = new WeightPriceDecorator(calculator, parcel);
                    subTotal += calculator.CalculatePrice();
                }

                var desc = calculator.GetDescription();

                IPriceCalculator gcalculator = new BasePrice(subTotal);
                var discountAmount = new ManiaCalculator().CalculateTotalCost(_parcels.ToList());
                gcalculator = new DiscountPriceDecorator(gcalculator, discountAmount);

                if (_fastDelivery)
                    gcalculator = new FastDeliveryPriceDecorator(gcalculator);

                var desc1 = gcalculator.GetDescription();
                return gcalculator.CalculatePrice();
            }
            return 0;
        }
    }
}
