namespace DomainLayer.Interfaces
{
    public interface IPricingAlgorithm
    {
        decimal CalculatePriceOnDay(Room room, DateTime date);
    }
}
