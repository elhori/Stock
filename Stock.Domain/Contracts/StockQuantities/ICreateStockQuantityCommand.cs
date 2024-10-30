namespace Stock.Domain.Contracts.StockQuantities;

public interface ICreateStockQuantityCommand
{
    decimal OriginalQuantity { get; }
    decimal ConvertedQuantity { get; }
    string UnitType { get; }
    int ItemId { get; }
}