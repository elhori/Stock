namespace Stock.Domain.Contracts.StockQuantities;

public record StockQuantityDto(
    int Id,
    decimal OriginalQuantity,
    decimal ConvertedQuantity,
    string UnitType,
    int ItemId,
    string ItemName);