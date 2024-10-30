using Stock.Domain.Contracts.InvoiceDetails;

namespace Stock.Domain.Contracts.ReceivingInvoices;

public record ReceivingInvoiceDto(
    int Id,
    DateTime ReceivingDate,
    string Supplier,
    decimal TotalAmount,
    List<InvoiceDetailDto> Details);