namespace Stock.Domain.Contracts.InvoiceDetails;

public interface IUpdateInvoiceDetailCommand
{
    int Id { get; }
    decimal QuantityReceived { get; }
    decimal UnitPrice { get; }
    int InvoiceId { get; }
    int ItemId { get; }
}