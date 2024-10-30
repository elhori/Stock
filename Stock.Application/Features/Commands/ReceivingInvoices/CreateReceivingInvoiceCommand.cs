using MediatR;
using Stock.Domain.Contracts.ReceivingInvoices;

namespace Stock.Application.Features.Commands.ReceivingInvoices;

public record CreateReceivingInvoiceCommand(
    DateTime ReceivingDate,
    string Supplier,
    decimal TotalAmount) : ICreateReceivingInvoiceCommand, IRequest<string>;