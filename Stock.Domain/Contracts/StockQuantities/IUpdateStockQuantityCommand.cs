namespace Stock.Domain.Contracts.StockQuantities;

public interface IUpdateStockQuantityCommand
{
    int Id { get; }
    decimal OriginalQuantity { get; }
    decimal ConvertedQuantity { get; }
    string UnitType { get; }
    int ItemId { get; }
}