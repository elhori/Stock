using MediatR;
using Stock.Domain.Contracts.ReceivingInvoices;

namespace Stock.Application.Features.Commands.ReceivingInvoices;

public record UpdateReceivingInvoiceCommand(
    int Id,
    DateTime ReceivingDate,
    string Supplier,
    decimal TotalAmount) : IUpdateReceivingInvoiceCommand, IRequest<string>;