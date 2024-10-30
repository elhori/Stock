using MediatR;
using Stock.Domain.Contracts.InvoiceDetails;

namespace Stock.Application.Features.Commands.InvoiceDetails;

public record GetInvoiceDetailCommand(int Id) : IRequest<InvoiceDetailDto>;