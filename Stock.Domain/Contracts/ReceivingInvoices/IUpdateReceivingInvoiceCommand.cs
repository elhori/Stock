namespace Stock.Domain.Contracts.ReceivingInvoices;

public interface IUpdateReceivingInvoiceCommand
{
    int Id { get; }
    DateTime ReceivingDate { get; }
    string Supplier { get; }
    decimal TotalAmount { get; }
}