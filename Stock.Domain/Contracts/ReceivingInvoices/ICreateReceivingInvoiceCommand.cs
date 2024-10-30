namespace Stock.Domain.Contracts.ReceivingInvoices;

public interface ICreateReceivingInvoiceCommand
{
    DateTime ReceivingDate { get; }
    string Supplier { get; }
    decimal TotalAmount { get; }
}