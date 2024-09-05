using PricingService.Sizes;

namespace PricingService.Discounts
{
    public class ManiaCalculator
    {
        public decimal CalculateTotalCost(IList<Parcel> parcels)
        { 
            decimal maxDiscount = CalculateMaxDiscount(parcels);
            return maxDiscount;
        }

        private decimal CalculateMaxDiscount(IList<Parcel> parcels)
        {
            var totalSmallDiscounts = CalculateSmallParcelDiscount(parcels);
            var totalMediumDiscounts = CalculateMediumParcelDiscount(parcels);
            var totalMixDiscounts = CalculateMixedParcelDiscount(parcels);
            return Max(totalSmallDiscounts + totalMediumDiscounts, totalMixDiscounts);
        }
        private decimal Max(params decimal[] values)
        {
            if (values == null || values.Length == 0)
            {
                throw new ArgumentException("At least one value must be provided.");
            }

            decimal max = values[0];

            foreach (decimal value in values)
            {
                if (value > max)
                {
                    max = value;
                }
            }

            return max;
        }

        private decimal CalculateSmallParcelDiscount(IList<Parcel> parcels)
        {
            var smallParcels = parcels.Where(p => Sizer.GetParcelSize(p) == ParcelSize.Small).ToList();
            return CalculateNthParcelFreeDiscount(smallParcels, 4);
        }

        private decimal CalculateMediumParcelDiscount(IList<Parcel> parcels)
        {
            var mediumParcels = parcels.Where(p => Sizer.GetParcelSize(p) == ParcelSize.Medium).ToList();
            return CalculateNthParcelFreeDiscount(mediumParcels, 3);
        }

        private decimal CalculateMixedParcelDiscount(IList<Parcel> parcels)
        {
            return CalculateNthParcelFreeDiscount(parcels, 5);
        }

        private decimal CalculateNthParcelFreeDiscount(IList<Parcel> parcels, int n)
        {
            decimal discount = 0;

            for (int i = n - 1; i < parcels.Count; i += n)
            {
                discount += Sizer.GetParcelCostBySize(Sizer.GetParcelSize(parcels[i]));
            }
            return discount;
        }
    }
}
