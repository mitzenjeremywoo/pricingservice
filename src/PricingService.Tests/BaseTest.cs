namespace PricingService.Tests
{
    public class BaseTest
    {
        public List<Parcel> CreateParcelsTest(int num, int parcelSizeType, int weight = 1)
        {
            var list = new List<Parcel>();
            for (int i = 0; i < num; i++)
            {
                list.Add(new Parcel(2, parcelSizeType, weight));
            }
            return list;
        }
    }
}
