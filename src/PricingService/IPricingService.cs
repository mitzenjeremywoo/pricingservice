namespace PricingService
{
    public interface IPriceCalculator
    {
        decimal CalculatePrice();
        string GetDescription();
    }
}
