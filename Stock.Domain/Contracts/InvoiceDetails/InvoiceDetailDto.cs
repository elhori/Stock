namespace Stock.Domain.Contracts.InvoiceDetails;

public record InvoiceDetailDto(
    int Id,
    decimal QuantityReceived,
    decimal UnitPrice,
    int InvoiceId,
    int ItemId,
    string ItemName);