using MediatR;
using Stock.Domain.Contracts.ReceivingInvoices;

namespace Stock.Application.Features.Commands.ReceivingInvoices;

public record GetReceivingInvoiceCommand(int Id) : IRequest<ReceivingInvoiceDto>;