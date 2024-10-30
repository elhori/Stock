using MediatR;
using Stock.Domain.Contracts.InvoiceDetails;

namespace Stock.Application.Features.Commands.InvoiceDetails;

public record UpdateInvoiceDetailCommand(
    int Id,
    decimal QuantityReceived,
    decimal UnitPrice,
    int InvoiceId,
    int ItemId) : IUpdateInvoiceDetailCommand, IRequest<string>;