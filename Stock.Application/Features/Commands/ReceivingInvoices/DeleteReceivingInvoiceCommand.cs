using MediatR;

namespace Stock.Application.Features.Commands.ReceivingInvoices;

public record DeleteReceivingInvoiceCommand(int Id) : IRequest<string>;