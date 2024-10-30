namespace Stock.Domain.Contracts.InvoiceDetails;

public interface ICreateInvoiceDetailCommand
{
    decimal QuantityReceived { get; }
    decimal UnitPrice { get; }
    int InvoiceId { get; }
    int ItemId { get; }
}