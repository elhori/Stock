using MediatR;
using Stock.Domain.Contracts.InvoiceDetails;

namespace Stock.Application.Features.Commands.InvoiceDetails;

public record CreateInvoiceDetailCommand(
    decimal QuantityReceived,
    decimal UnitPrice,
    int InvoiceId,
    int ItemId) : ICreateInvoiceDetailCommand, IRequest<string>;