using MediatR;

namespace Stock.Application.Features.Commands.InvoiceDetails;

public record DeleteInvoiceDetailCommand(int Id) : IRequest<string>;